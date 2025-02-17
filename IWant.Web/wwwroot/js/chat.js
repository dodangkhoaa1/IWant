$(document).ready(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();
    var plusIcon = document.getElementById("plus-icon");

    connection.start().then(function () {
        console.log('SignalR Started...')
        viewModel.roomList();
        viewModel.userList();
    })
        .catch(function (err) {
            return console.error(err);
        });

    connection.on("newMessage", function (messageView) {
        var isMine = messageView.from === viewModel.myName();
        console.log(isMine);
        var message = new ChatMessage(messageView.content, messageView.timeStamp, messageView.from, isMine, messageView.avatar);
        viewModel.chatMessages.push(message);
        $(".chat-body").animate({ scrollTop: $(".chat-body")[0].scrollHeight }, 1000);
    });


    connection.on("addChatRoom", function (room) {
        viewModel.roomAdded(new ChatRoom(room.id, room.name));
    });

    connection.on("getProfileInfo", function (displayName, avatar) {
        viewModel.myName(displayName);
        viewModel.myAvatar(avatar);
        viewModel.isLoading(false);
    });

    connection.on("addUser", function (user) {
        viewModel.userAdded(new ChatUser(user.username, user.fullName, user.avatar, user.currentRoom, user.device));
    });

    connection.on("removeUser", function (user) {
        viewModel.userRemoved(user.username);
    });

    connection.on("updateChatRoom", function (room) {
        viewModel.roomUpdated(new ChatRoom(room.id, room.name));
    });

    connection.on("removeChatRoom", function (id) {
        viewModel.roomDeleted(id);
    });

    connection.on("onRoomDeleted", function (message) {
        viewModel.serverInfoMessage(message);
        $("errorAlert").removeClass("d-none").show().delay(5000).fadeOut(500);

        if (viewModel.chatRooms().length == 0) {
            viewModel.joinedRoom("");
        }
        else {
            setTimeout(function () {
                $("ul#room-list li a")[0].click();
            }, 50);
        }
    });

    function AppViewModel() {
        var self = this;
        self.message = ko.observable("");
        self.chatRooms = ko.observableArray([]);
        self.chatUsers = ko.observableArray([]);
        self.chatMessages = ko.observableArray([]);
        self.joinedRoom = ko.observable("");
        self.joinedRoomId = ko.observable("");
        self.serverInfoMessage = ko.observable("");
        self.myName = ko.observable("");
        self.myAvatar = ko.observable("");
        self.isLoading = ko.observable(true);

        self.joinRoom = function (room) {
            connection.invoke("Join", room.name()).then(function () {
                self.joinedRoom(room.name());
                self.joinedRoomId(room.id());
                self.userList();
                self.messageHistory();
            })
        }

        self.onEnter = function (d, e) {
            if (e.keyCode === 13) {
                self.sendNewMessage();
            }
            return true;
        }

        self.filter = ko.observable("");
        self.filteredChatUsers = ko.computed(function () {
            if (!self.filter()) {
                return self.chatUsers();
            } else {
                return ko.utils.arrayFilter(self.chatUsers(), function (user) {
                    var displayName = user.displayName().toLowerCase();
                    return displayName.includes(self.filter().toLowerCase());
                });
            }
        });

        self.sendNewMessage = function () {
            var text = self.message();

            if (text.startsWith("/")) {
                var receiver = text.substring(text.indexOf("(") + 1, text.indexOf(")"));
                var message = text.substring(text.indexOf(")") + 1, text.length);
                self.sendPrivate(receiver, message);
            }
            else {
                self.sendToRoom(self.joinedRoom(), self.message());
            }
            self.message("");
        }

        self.sendToRoom = function (roomName, message) {
            if (roomName.length > 0 && message.length > 0) {
                fetch('/Chat/Create', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ room: roomName, content: message })
                });
            }
        }

        self.sendPrivate = function (receiver, message) {
            if (receiver.length > 0 && message.length > 0) {
                connection.invoke("SendPrivate", receiver.trim(), message.trim());
            }
        }

        self.roomList = function () {
            fetch('/Room/GetRooms')
                .then(response => response.json())
                .then(data => {
                    self.chatRooms.removeAll();
                    if (data.length == 0) {
                        plusIcon.style.display = "none";
                    } 
                    for (var i = 0; i < data.length; i++) {
                        self.chatRooms.push(new ChatRoom(data[i].Id, data[i].Name));
                    }
                });

            fetch('/Room/GetRooms')
                .then(response => response.json())
                .then(data => console.log(data))
                .catch(error => console.error("Fetch error:", error));
        }

        self.roomAdded = function (room) {
            self.chatRooms.push(room);
        }

        self.createRoom = function () {
            var roomName = $("#roomName").val();
            console.log("Sending room name:", roomName);
            fetch('/Room/Create', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ name: roomName })
            });
        }

        self.editRoom = function () {
            var roomId = self.joinedRoomId();
            var roomName = $("#newRoomName").val();
            fetch('/Room/Edit/' + roomId, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: roomId, name: roomName })
            });
        }

        self.deleteRoom = function () {
            fetch('/Room/Delete/' + self.joinedRoomId(), {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: self.joinedRoomId() })
            });
        }

        self.messageHistory = function () {
            console.log('/Chat/Messages/' + viewModel.joinedRoom());
            fetch('/Chat/Messages/' + viewModel.joinedRoom())
                .then(response => response.json())
                .then(data => {
                    self.chatMessages.removeAll();
                    for (var i = 0; i < data.length; i++) {
                        var isMine = data[i].From == self.myName();
                        self.chatMessages.push(new ChatMessage(data[i].Content,
                            data[i].TimeStamp,
                            data[i].From,
                            isMine,
                            data[i].Avatar));
                        console.log(data[i]);
                    }

                    $(".chat-body").animate({ scrollTop: $(".chat-body")[0].scrollHeight }, 1000);
                });
        }

        self.roomUpdated = function (updatedRoom) {
            var room = ko.utils.arrayFirst(self.chatRooms(), function (item) {
                return updatedRoom.id() == item.id();
            });

            room.name(updatedRoom.name());

            if (self.joinedRoomId() == room.id()) {
                self.joinRoom(room);
            }
        }

        self.roomDeleted = function (id) {
            var temp;
            ko.utils.arrayForEach(self.chatRooms(), function (room) {
                if (room.id() == id)
                    temp = room;
            });
            self.chatRooms.remove(temp);
        }

        self.userAdded = function (user) {
            self.chatUsers.push(user);
        }

        self.userRemoved = function (id) {
            var temp;
            ko.utils.arrayForEach(self.chatUsers(), function (user) {
                if (user.id() == id)
                    temp = user;
            });
            self.chatUsers.remove(temp);
        }

        self.uploadFiles = function () {
            var form = document.getElementById("uploadForm");
            $.ajax({
                type: "POST",
                url: "/Upload/Upload",
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (data) {
                    $("#UploadFile").val("");
                },
                error: function (data) {
                    alert('Error: ' + error.responseText);
                }
            });
        }

        self.userList = function () {
            connection.invoke("GetUsers", self.joinedRoom()).then(function (result) {
                self.chatUsers.removeAll();
                for (var i = 0; i < result.length; i++) {
                    self.chatUsers.push(new ChatUser(result[i].username,
                        result[i].fullName,
                        result[i].avatar == null ? "default-avatar.png" : result[i].avatar,
                        result[i].currentRoom,
                        result[i].device))
                }
            });
        }
    }

    function ChatUser(userName, displayName, avatar, currentRoom, device) {
        var self = this;
        self.username = ko.observable(userName);
        self.displayName = ko.observable(displayName);
        self.avatar = ko.observable(avatar);
        self.currentRoom = ko.observable(currentRoom);
        self.device = ko.observable(device);
    }

    function ChatRoom(id, name) {
        var self = this;
        self.id = ko.observable(id);
        self.name = ko.observable(name);
    }

    function ChatMessage(Content, TimeStamp, From, isMine, Avatar) {
        var self = this;
        self.content = ko.observable(Content);
        self.timestamp = ko.observable(TimeStamp);
        self.from = ko.observable(From);    
        self.isMine = ko.observable(isMine);
        self.avatar = ko.observable(Avatar);
    }

    
    var viewModel = new AppViewModel();
    ko.applyBindings(viewModel);
});