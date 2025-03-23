using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.Web.Models;

namespace IWant.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageViewModel>()
                .ForMember(dst => dst.From, otp => otp.MapFrom(x => x.FromUser.FullName))
                .ForMember(dst => dst.Room, otp => otp.MapFrom(x => x.ToRoom.Id))
                .ForMember(dst => dst.Avatar, otp => otp.MapFrom(x => x.FromUser.ImageUrl))
                .ForMember(dst => dst.From, otp => otp.MapFrom(x => x.FromUser.FullName))
                .ForMember(dst => dst.TimeStamp, otp => otp.MapFrom(x => x.TimeStamp));
            CreateMap<MessageViewModel, Message>();


            CreateMap<ChatRoom, ChatRoomViewModel>();
            CreateMap<ChatRoomViewModel, ChatRoom>();

            CreateMap<BlogViewModel, Blog>();
            CreateMap<Blog, BlogViewModel>();

            CreateMap<User, UserViewModel>().ForMember(dst=>dst.Username, opt => opt.MapFrom(x=>x.UserName));
            CreateMap<UserViewModel, User>();

            CreateMap<User, AccountViewModel>();
            CreateMap<AccountViewModel, User>();
            
            CreateMap<User, AccountDetailViewModel>();
            CreateMap<AccountDetailViewModel, User>();

            CreateMap<Feedback, FeedbackViewModel>();
            CreateMap<FeedbackViewModel, Feedback>();

            CreateMap<Rate, RateViewModel>();
            CreateMap<RateViewModel, Rate>();

            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel, Game>();
        }
    }
}
