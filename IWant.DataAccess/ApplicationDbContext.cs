using IWant.BusinessObject.Enitities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Reflection.Emit;

namespace IWant.DataAccess;

public partial class ApplicationDbContext : IdentityDbContext<User>
{

    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<WordCategory> WordCategories { get; set; }
    public virtual DbSet<Word> Words { get; set; }
    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Rate> Rates { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<PersonalWord> PersonalWords { get; set; }
    public virtual DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"),
            server => server.EnableRetryOnFailure());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "d19bb620-77b5-414e-865a-1894fbcbb689",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "fbd6a6c8-27eb-4171-bb75-50e97adffebb",
                Name = "Member",
                NormalizedName = "MEMBER"
            });

        builder.Entity<User>(entity =>
        {
            entity.ToTable("AspNetUsers");
        });

        builder.Entity<User>().HasData(
            new User
            {
                Id = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
                FullName = "Hồ Minh Nhật",
                ImageUrl = "http://localhost:5130/images/avatar/default-avatar.png",
                ImageLocalPath = "default-avatar.png",
                PhoneNumber = "0888408052",
                Gender = true,
                Birthday = DateOnly.Parse("2003-11-24"),
                Status = true,
                UserName = "nhathm2411@gmail.com",
                NormalizedUserName = "NHATHM2411@GMAIL.COM",
                Email = "nhathm2411@gmail.com",
                NormalizedEmail = "NHATHM2411@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==",
                SecurityStamp = "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY",
                ConcurrencyStamp = "bd591428-5d71-49ee-abd2-c1740ff5f70c",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new User
            {
                Id = "15ccf7a4-8f9f-4127-b046-69723542fc06",
                FullName = "Nguyễn Huỳnh Như",
                ImageUrl = "http://localhost:5130/images/avatar/default-avatar.png",
                ImageLocalPath = "default-avatar.png",
                PhoneNumber = "0888408052",
                Gender = false,
                Birthday = DateOnly.Parse("2003-11-24"),
                Status = true,
                UserName = "nhathmce170171@fpt.edu.vn",
                NormalizedUserName = "NHATHMCE170171@FPT.EDU.VN",
                Email = "nhathmce170171@fpt.edu.vn",
                NormalizedEmail = "NHATHMCE170171@FPT.EDU.VN",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==",
                SecurityStamp = "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY",
                ConcurrencyStamp = "bd591428-5d71-49ee-abd2-c1740ff5f70c",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new User
            {
                Id = "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012",
                FullName = "Đỗ Đăng Khoa",
                ImageUrl = "http://localhost:5130/images/avatar/default-avatar.png",
                ImageLocalPath = "default-avatar.png",
                PhoneNumber = "0784419071",
                Gender = true,
                Birthday = DateOnly.Parse("2003-07-16"),
                Status = true,
                UserName = "ddkhoaa1@gmail.com",
                NormalizedUserName = "DDKHOAA1@GMAIL.COM",
                Email = "ddkhoaa1@gmail.com",
                NormalizedEmail = "DDKHOAA1@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==",
                SecurityStamp = "ZBIKDBKDV6SC53SMC5UX6ASTZB3G55FE",
                ConcurrencyStamp = "4209a34d-673a-423b-bf3b-f9e180f4a012",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            }
            );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
                RoleId = "d19bb620-77b5-414e-865a-1894fbcbb689"
            },
            new IdentityUserRole<string>
            {
                UserId = "15ccf7a4-8f9f-4127-b046-69723542fc06",
                RoleId = "fbd6a6c8-27eb-4171-bb75-50e97adffebb"
            },
            new IdentityUserRole<string>
            {
                UserId = "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012",
                RoleId = "fbd6a6c8-27eb-4171-bb75-50e97adffebb"
            }
        );

        //Blogs
        builder.Entity<Blog>().HasData(
     new Blog
     {
         Id = 1,
         Title = "Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn",
         Content = @"<p style=""text-align: justify; ""><strong>Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn</strong></p>

                    <p style=""text-align: justify;"">Cha mẹ nào cũng muốn con cái chia sẻ, tâm sự mọi chuyện. Nhưng không phải lúc nào trẻ cũng sẵn sàng mở lòng. Làm sao để con cảm thấy thoải mái khi trò chuyện, tránh xa khoảng cách thế hệ và thực sự kết nối với cha mẹ? Hãy cùng tìm hiểu cách giao tiếp cởi mở với con một cách tự nhiên nhất!</p>

                    <p style=""text-align: justify;""><strong>Vì sao giao tiếp cởi mở với con lại quan trọng?</strong></p>

                    <p style=""text-align: justify;"">Trẻ nhỏ, đặc biệt là lứa tuổi dậy thì, rất cần một người lắng nghe và thấu hiểu. Khi cha mẹ tạo ra không gian an toàn, trẻ sẽ dễ dàng chia sẻ suy nghĩ, cảm xúc của mình hơn. Điều này không chỉ giúp gắn kết tình cảm gia đình mà còn giúp trẻ tự tin hơn trong cuộc sống.</p>

                    <p style=""text-align: justify;""><strong>Một số lợi ích của việc trò chuyện cởi mở với con:</strong></p>

                    <ul>
                        <li style=""text-align: justify;"">Giúp trẻ cảm thấy được yêu thương và tôn trọng.</li>
                        <li style=""text-align: justify;"">Giúp cha mẹ hiểu rõ những vấn đề mà con đang gặp phải.</li>
                        <li style=""text-align: justify;"">Tạo nền tảng cho sự phát triển tâm lý lành mạnh.</li>
                        <li style=""text-align: justify;"">Giúp trẻ học cách diễn đạt suy nghĩ và cảm xúc một cách rõ ràng.</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Cách nói chuyện cởi mở với con</strong></p>

                    <p style=""text-align: justify;""><strong>Chọn thời điểm phù hợp</strong></p>

                    <p style=""text-align: justify;"">Hãy trò chuyện với con vào lúc cả hai đều thoải mái. Đừng ép con nói chuyện khi con đang mệt mỏi, căng thẳng hoặc bị phân tâm bởi điện thoại, TV.</p>

                    <p style=""text-align: justify;""><strong>Lắng nghe thay vì phán xét</strong></p>

                    <p style=""text-align: justify;"">Nhiều bậc cha mẹ có xu hướng đưa ra lời khuyên hoặc phán xét ngay khi con nói. Tuy nhiên, trẻ cần cảm giác được lắng nghe hơn là bị chỉ trích. Thay vì nói “Con không nên làm vậy!”, hãy thử hỏi “Con nghĩ sao về điều đó?” để khuyến khích con chia sẻ.</p>

                    <p style=""text-align: justify;""><strong>Đặt câu hỏi mở</strong></p>

                    <p style=""text-align: justify;"">Tránh những câu hỏi “Có” hoặc “Không” vì chúng dễ làm cuộc trò chuyện đi vào ngõ cụt. Thay vào đó, hãy đặt câu hỏi mở để kích thích con suy nghĩ và diễn đạt nhiều hơn, ví dụ:</p>

                    <ul>
                        <li style=""text-align: justify;"">Hôm nay ở trường có chuyện gì thú vị không?</li>
                        <li style=""text-align: justify;"">Con cảm thấy thế nào về điều đó?</li>
                        <li style=""text-align: justify;"">Nếu được làm lại, con sẽ làm khác đi như thế nào?</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Tạo không gian thoải mái</strong></p>

                    <p style=""text-align: justify;"">Không phải lúc nào cũng cần ngồi nghiêm túc để nói chuyện. Những lúc cùng con nấu ăn, đi dạo hay trên đường đi học cũng là cơ hội tốt để bắt đầu cuộc trò chuyện.</p>

                    <p style=""text-align: justify;""><strong>Thể hiện sự đồng cảm</strong></p>

                    <p style=""text-align: justify;"">Khi con gặp vấn đề, hãy đặt mình vào vị trí của con. Thay vì nói ""Chuyện này không có gì to tát"", hãy thử nói ""Mẹ hiểu tại sao con cảm thấy như vậy"". Điều này giúp con cảm nhận được sự thấu hiểu từ cha mẹ.</p>

                    <p style=""text-align: justify;""><strong>Những điều cần tránh khi trò chuyện với con</strong></p>

                    <ul>
                        <li style=""text-align: justify;""><strong>Không áp đặt suy nghĩ:</strong> Tránh những câu như “Con phải làm thế này mới đúng!” vì trẻ cần có không gian để tự quyết định.</li>
                        <li style=""text-align: justify;""><strong>Không so sánh con với người khác:</strong> Câu nói “Sao con không giỏi như bạn A?” chỉ khiến trẻ tự ti và xa cách cha mẹ hơn.</li>
                        <li style=""text-align: justify;""><strong>Không chỉ trích hoặc quát mắng:</strong> Khi trẻ mắc lỗi, thay vì trách mắng, hãy giúp con hiểu vấn đề và tìm hướng giải quyết.</li>
                        <li style=""text-align: justify;""><strong>Không đặt câu hỏi quá dồn dập:</strong> Điều này có thể làm con cảm thấy như đang bị tra khảo thay vì được tâm sự.</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Kết luận</strong></p>

                    <p style=""text-align: justify;"">Trò chuyện với con không phải là một nhiệm vụ khó khăn, quan trọng là cha mẹ biết cách lắng nghe, thấu hiểu và tôn trọng con. Khi cha mẹ thực sự quan tâm và đồng hành, con sẽ tự nhiên mở lòng, giúp mối quan hệ gia đình ngày càng gắn kết hơn.</p>",
         CreatedAt = new DateTime(2025, 3, 10, 12, 30, 42),
         UpdatedAt = new DateTime(2025, 3, 10, 12, 30, 42),
         ImageUrl = "http://localhost:5130/images/blog/1.svg",
         ImageLocalPath = "blog\\1.svg",
         Status = true,
         ViewCount = 1,
         UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
         CitedImage = "Sưu tầm"
     }
);

        builder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 2,
                Title = "Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp",
                Content = @"<p style=""text-align: justify;""><strong>Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp</strong></p>
                    <p style=""text-align: justify;"">Ngày nay, mạng xã hội đã trở thành một phần không thể thiếu trong cuộc sống, đặc biệt là đối với giới trẻ. Tuy nhiên, việc sử dụng mạng xã hội quá mức có thể gây ra nhiều tác động tiêu cực đến tâm lý và sự phát triển của trẻ em, thậm chí làm gia tăng nguy cơ rối loạn tâm trí.</p>
                    
                    <p style=""text-align: justify;""><strong>1. Trẻ em nghiện mạng xã hội: Thực trạng đáng lo ngại</strong></p>
                    <p style=""text-align: justify;"">Với sự phát triển của công nghệ, trẻ em ngày càng tiếp cận sớm với điện thoại, máy tính bảng và các nền tảng mạng xã hội như Facebook, TikTok, Instagram...</p>

                    <p style=""text-align: justify;""><strong>2. Tác hại của việc nghiện mạng xã hội</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Rối loạn tâm lý:</strong> Việc tiếp xúc với quá nhiều nội dung tiêu cực...</li>
                        <li style=""text-align: justify;""><strong>Rối loạn giấc ngủ:</strong> Trẻ thường xuyên sử dụng điện thoại...</li>
                        <li style=""text-align: justify;""><strong>Suy giảm khả năng tập trung:</strong> Sử dụng mạng xã hội quá mức...</li>
                    </ul>
                    
                    <p style=""text-align: justify;""><strong>3. Nguyên nhân khiến trẻ nghiện mạng xã hội</strong></p>
                    <p style=""text-align: justify;"">Có nhiều yếu tố dẫn đến tình trạng này, bao gồm...</p>

                    <p style=""text-align: justify;""><strong>4. Cách giúp trẻ sử dụng mạng xã hội một cách lành mạnh</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Đặt giới hạn thời gian sử dụng:</strong> Thiết lập quy tắc rõ ràng...</li>
                        <li style=""text-align: justify;""><strong>Giám sát nội dung trẻ tiếp cận:</strong> Sử dụng các công cụ kiểm soát...</li>
                        <li style=""text-align: justify;""><strong>Trở thành tấm gương tốt:</strong> Cha mẹ cũng nên hạn chế sử dụng điện thoại...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Kết luận</strong></p>
                    <p style=""text-align: justify;"">Mạng xã hội mang lại nhiều lợi ích nhưng cũng tiềm ẩn nhiều rủi ro...</p>",
                CreatedAt = new DateTime(2025, 3, 22, 12, 35, 48),
                UpdatedAt = new DateTime(2025, 3, 22, 12, 35, 48),
                ImageUrl = "http://localhost:5130/images/blog/2.svg",
                ImageLocalPath = "blog\\2.svg",
                Status = true,
                ViewCount = 1,
                UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
                CitedImage = "Sưu tầm"
            }
        );

        builder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 3,
                Title = "Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ",
                Content = @"<p style=""text-align: justify;""><strong>Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ</strong></p>
                    <p style=""text-align: justify;"">Phương pháp AAC (Augmentative and Alternative Communication) là một hệ thống giao tiếp bổ trợ và thay thế giúp những người gặp khó khăn trong giao tiếp bằng lời nói, đặc biệt là trẻ tự kỷ...</p>

                    <p style=""text-align: justify;""><strong>1. AAC là gì?</strong></p>
                    <p style=""text-align: justify;"">AAC bao gồm nhiều phương pháp khác nhau nhằm hỗ trợ hoặc thay thế ngôn ngữ nói...</p>

                    <p style=""text-align: justify;""><strong>2. Vì sao AAC quan trọng đối với trẻ tự kỷ?</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Giúp trẻ thể hiện nhu cầu:</strong> Hạn chế căng thẳng...</li>
                        <li style=""text-align: justify;""><strong>Phát triển kỹ năng giao tiếp:</strong> Hỗ trợ trẻ học cách tương tác...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>3. Các phương pháp AAC phổ biến</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>PECS:</strong> Hệ thống giao tiếp bằng tranh ảnh...</li>
                        <li style=""text-align: justify;""><strong>Ứng dụng hỗ trợ giao tiếp:</strong> Một số ứng dụng trên điện thoại...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>4. Khi nào nên áp dụng AAC?</strong></p>
                    <p style=""text-align: justify;"">AAC có thể được áp dụng cho trẻ tự kỷ ngay từ khi phát hiện trẻ có dấu hiệu chậm nói...</p>

                    <p style=""text-align: justify;""><strong>5. Lưu ý khi sử dụng AAC</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Chọn phương pháp phù hợp:</strong> Mỗi trẻ có khả năng khác nhau...</li>
                        <li style=""text-align: justify;""><strong>Kiên nhẫn và luyện tập:</strong> Cha mẹ và giáo viên cần hướng dẫn...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Kết luận</strong></p>
                    <p style=""text-align: justify;"">Phương pháp AAC là một công cụ hỗ trợ hiệu quả giúp trẻ tự kỷ cải thiện kỹ năng giao tiếp...</p>",
                CreatedAt = new DateTime(2025, 3, 28, 12, 38, 23),
                UpdatedAt = new DateTime(2025, 3, 28, 12, 38, 23),
                ImageUrl = "http://localhost:5130/images/blog/3.svg",
                ImageLocalPath = "blog\\3.svg",
                Status = true,
                ViewCount = 1,
                UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
                CitedImage = "Sưu tầm"
            }
        );

        builder.Entity<Blog>().HasData(
            new Blog
            {
                Id = 4,
                Title = "Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống",
                Content = @"<p style=""text-align: justify;""><strong>Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống</strong></p>
                    <p style=""text-align: justify;"">Tự kỷ không phải là một căn bệnh, mà là một dạng rối loạn phát triển ảnh hưởng đến khả năng giao tiếp...</p>

                    <p style=""text-align: justify;""><strong>1. Dấu hiệu nhận biết trẻ tự kỷ</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Hạn chế giao tiếp bằng mắt:</strong> Trẻ ít hoặc không duy trì giao tiếp bằng mắt khi trò chuyện.</li>
                        <li style=""text-align: justify;""><strong>Không phản ứng khi được gọi tên:</strong> Nhiều trẻ không quay lại...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>2. Tại sao cần phát hiện và can thiệp sớm?</strong></p>
                    <ul>
                        <li style=""text-align: justify;"">Cải thiện khả năng ngôn ngữ và giao tiếp.</li>
                        <li style=""text-align: justify;"">Giảm thiểu các hành vi tiêu cực...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>3. Những phương pháp can thiệp hiệu quả</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Liệu pháp ngôn ngữ:</strong> Giúp trẻ cải thiện khả năng giao tiếp...</li>
                        <li style=""text-align: justify;""><strong>Liệu pháp hành vi (ABA):</strong> Dạy trẻ cách phản ứng phù hợp...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>4. Vai trò của gia đình trong việc hỗ trợ trẻ tự kỷ</strong></p>
                    <ul>
                        <li style=""text-align: justify;""><strong>Kiên nhẫn và thấu hiểu:</strong> Mỗi trẻ tự kỷ đều có thế mạnh riêng...</li>
                        <li style=""text-align: justify;""><strong>Tạo môi trường giao tiếp tích cực:</strong> Thường xuyên trò chuyện...</li>
                    </ul>

                    <p style=""text-align: justify;""><strong>Kết luận</strong></p>
                    <p style=""text-align: justify;"">Trẻ tự kỷ có thể phát triển và hòa nhập xã hội nếu được phát hiện sớm và can thiệp đúng cách...</p>",
                CreatedAt = new DateTime(2025, 3, 29, 12, 42, 05),
                UpdatedAt = new DateTime(2025, 3, 29, 12, 42, 05),
                ImageUrl = "http://localhost:5130/images/blog/4.svg",
                ImageLocalPath = "blog\\4.svg",
                Status = true,
                ViewCount = 0,
                UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
                CitedImage = "Sưu tầm"
            }
        );

        //Word Category
        builder.Entity<WordCategory>().HasData(
            new WordCategory() { Id = 1, VietnameseName = "Từ Cá Nhân", EnglishName = "Personal Words", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Personal.png", Status = true },
            new WordCategory() { Id = 2, VietnameseName = "Hành Động", EnglishName = "Actions", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Actions.png", Status = true },
            new WordCategory() { Id = 3, VietnameseName = "Động Vật", EnglishName = "Animals", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Animals.png", Status = true },
            new WordCategory() { Id = 4, VietnameseName = "Bộ Phận Cơ Thể", EnglishName = "Body Parts", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/BodyParts.png", Status = true },
            new WordCategory() { Id = 5, VietnameseName = "Quần Áo", EnglishName = "Clothes", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Clothes.png", Status = true },
            new WordCategory() { Id = 6, VietnameseName = "Màu Sắc", EnglishName = "Colors", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Colors.png", Status = true },
            new WordCategory() { Id = 7, VietnameseName = "Cảm Xúc", EnglishName = "Feeling", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Feeling.png", Status = true },
            new WordCategory() { Id = 8, VietnameseName = "Thức Ăn", EnglishName = "Food", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Food.png", Status = true },
            new WordCategory() { Id = 9, VietnameseName = "Trái Cây", EnglishName = "Fruits", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Fruits.png", Status = true },
            new WordCategory() { Id = 10, VietnameseName = "Con Số", EnglishName = "Numbers", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Numbers.png", Status = true },
            new WordCategory() { Id = 11, VietnameseName = "Con Người", EnglishName = "People", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/People.png", Status = true },
            new WordCategory() { Id = 12, VietnameseName = "Địa Điểm", EnglishName = "Places", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Places.png", Status = true },
            new WordCategory() { Id = 13, VietnameseName = "Câu Hỏi", EnglishName = "Questions", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Questions.png", Status = true },
            new WordCategory() { Id = 14, VietnameseName = "Mối Quan Hệ", EnglishName = "Relations", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Relations.png", Status = true },
            new WordCategory() { Id = 15, VietnameseName = "Thời Gian", EnglishName = "Time", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Time.png", Status = true },
            new WordCategory() { Id = 16, VietnameseName = "Đồ Chơi", EnglishName = "Toys", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Toys.png", Status = true },
            new WordCategory() { Id = 17, VietnameseName = "Phương Tiện", EnglishName = "Vehicles", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Vehicles.png", Status = true },
            new WordCategory() { Id = 18, VietnameseName = "Mong Muốn", EnglishName = "Want", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/wordCategories/Want.png", Status = true }
        );


        //Word
        //Action 
        builder.Entity<Word>().HasData(
            new Word() { Id = 1, VietnameseText = "Chải Tóc", EnglishText = "Brush Hair", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Brush hair.png", Status = true },
            new Word() { Id = 2, VietnameseText = "Đánh Răng", EnglishText = "Brush Teeth", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Brush teeth.png", Status = true },
            new Word() { Id = 3, VietnameseText = "Đóng", EnglishText = "Close", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Close.png", Status = true },
            new Word() { Id = 4, VietnameseText = "Uống", EnglishText = "Drink", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Drink.png", Status = true },
            new Word() { Id = 5, VietnameseText = "Ăn", EnglishText = "Eat", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Eat.png", Status = true },
            new Word() { Id = 6, VietnameseText = "Nhìn", EnglishText = "Look", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Look.png", Status = true },
            new Word() { Id = 7, VietnameseText = "Tắt", EnglishText = "Off", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Off.png", Status = true },
            new Word() { Id = 8, VietnameseText = "Bật", EnglishText = "On", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/On.png", Status = true },
            new Word() { Id = 9, VietnameseText = "Mở", EnglishText = "Open", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Open.png", Status = true },
            new Word() { Id = 10, VietnameseText = "Chơi", EnglishText = "Play", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Play.png", Status = true },
            new Word() { Id = 11, VietnameseText = "Mặc Vào", EnglishText = "Put On", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Put on.png", Status = true },
            new Word() { Id = 12, VietnameseText = "Chạy", EnglishText = "Run", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Run.png", Status = true },
            new Word() { Id = 13, VietnameseText = "Ngồi", EnglishText = "Sit", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Sit.png", Status = true },
            new Word() { Id = 14, VietnameseText = "Ngủ", EnglishText = "Sleep", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Sleep.png", Status = true },
            new Word() { Id = 15, VietnameseText = "Đứng", EnglishText = "Stand", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Stand.png", Status = true },
            new Word() { Id = 16, VietnameseText = "Bơi", EnglishText = "Swim", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Swim.png", Status = true },
            new Word() { Id = 17, VietnameseText = "Cởi Ra", EnglishText = "Take Off", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Take off.png", Status = true },
            new Word() { Id = 18, VietnameseText = "Nói Chuyện", EnglishText = "Talk", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Talk.png", Status = true },
            new Word() { Id = 19, VietnameseText = "Thức Dậy", EnglishText = "Wake Up", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Wake up.png", Status = true },
            new Word() { Id = 20, VietnameseText = "Đi", EnglishText = "Go", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Go.png", Status = true },
            new Word() { Id = 21, VietnameseText = "Rửa Tay", EnglishText = "Wash", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/actions/Wash.png", Status = true }
        );

        //Animal
        builder.Entity<Word>().HasData(
            new Word() { Id = 22, VietnameseText = "Ong", EnglishText = "Bee", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Bee.png", Status = true },
            new Word() { Id = 23, VietnameseText = "Chim", EnglishText = "Bird", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Bird.png", Status = true },
            new Word() { Id = 24, VietnameseText = "Bướm", EnglishText = "Butterfly", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Butterfly.png", Status = true },
            new Word() { Id = 25, VietnameseText = "Mèo", EnglishText = "Cat", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Cat.png", Status = true },
            new Word() { Id = 26, VietnameseText = "Gà", EnglishText = "Chicken", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Chicken.png", Status = true },
            new Word() { Id = 27, VietnameseText = "Bò", EnglishText = "Cow", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Cow.png", Status = true },
            new Word() { Id = 28, VietnameseText = "Chó", EnglishText = "Dog", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Dog.png", Status = true },
            new Word() { Id = 29, VietnameseText = "Vịt", EnglishText = "Duck", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Duck.png", Status = true },
            new Word() { Id = 30, VietnameseText = "Cá", EnglishText = "Fish", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Fish.png", Status = true },
            new Word() { Id = 31, VietnameseText = "Ngựa", EnglishText = "Horse", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Horse.png", Status = true },
            new Word() { Id = 32, VietnameseText = "Chuột", EnglishText = "Mouse", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Mouse.png", Status = true },
            new Word() { Id = 33, VietnameseText = "Heo", EnglishText = "Pig", WordCategoryId = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/animals/Pig.png", Status = true }
        );

        //Body part
        builder.Entity<Word>().HasData(
            new Word() { Id = 34, VietnameseText = "Cánh tay", EnglishText = "Arm", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Arm.png", Status = true },
            new Word() { Id = 35, VietnameseText = "Lưng", EnglishText = "Back", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Back.png", Status = true },
            new Word() { Id = 36, VietnameseText = "Bụng", EnglishText = "Belly", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Belly.png", Status = true },
            new Word() { Id = 37, VietnameseText = "Mông", EnglishText = "Bottom", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Bottom.png", Status = true },
            new Word() { Id = 38, VietnameseText = "Tai", EnglishText = "Ear", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Ear.png", Status = true },
            new Word() { Id = 39, VietnameseText = "Mắt", EnglishText = "Eye", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Eye.png", Status = true },
            new Word() { Id = 40, VietnameseText = "Khuôn mặt", EnglishText = "Face", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Face.png", Status = true },
            new Word() { Id = 41, VietnameseText = "Ngón tay", EnglishText = "Finger", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Finger.png", Status = true },
            new Word() { Id = 42, VietnameseText = "Bàn chân", EnglishText = "Foot", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Foot.png", Status = true },
            new Word() { Id = 43, VietnameseText = "Tóc", EnglishText = "Hair", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Hair.png", Status = true },
            new Word() { Id = 44, VietnameseText = "Bàn tay", EnglishText = "Hand", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Hand.png", Status = true },
            new Word() { Id = 45, VietnameseText = "Chân", EnglishText = "Leg", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Leg.png", Status = true },
            new Word() { Id = 46, VietnameseText = "Môi", EnglishText = "Lips", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Lips.png", Status = true },
            new Word() { Id = 47, VietnameseText = "Mũi", EnglishText = "Nose", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Nose.png", Status = true },
            new Word() { Id = 48, VietnameseText = "Răng", EnglishText = "Teeth", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Teeth.png", Status = true },
            new Word() { Id = 49, VietnameseText = "Họng", EnglishText = "Throat", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Throat.png", Status = true },
            new Word() { Id = 50, VietnameseText = "Ngón chân", EnglishText = "Toe", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Toe.png", Status = true },
            new Word() { Id = 51, VietnameseText = "Lưỡi", EnglishText = "Tongue", WordCategoryId = 4, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/bodyParts/Tongue.png", Status = true }
        );

        //clothes
        builder.Entity<Word>().HasData(
            new Word() { Id = 52, VietnameseText = "Ba lô", EnglishText = "Backpack", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Backpack.png", Status = true },
            new Word() { Id = 53, VietnameseText = "Mũ lưỡi trai", EnglishText = "Cap", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Cap.png", Status = true },
            new Word() { Id = 54, VietnameseText = "Áo khoác", EnglishText = "Jacket", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Jacket.png", Status = true },
            new Word() { Id = 55, VietnameseText = "Đồ ngủ", EnglishText = "Pajamas", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Pajamas.png", Status = true },
            new Word() { Id = 56, VietnameseText = "Quần dài", EnglishText = "Pants", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Pants.png", Status = true },
            new Word() { Id = 57, VietnameseText = "Khăn quàng cổ", EnglishText = "Scarf", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Scarf.png", Status = true },
            new Word() { Id = 58, VietnameseText = "Áo sơ mi", EnglishText = "Shirt", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Shirt.png", Status = true },
            new Word() { Id = 59, VietnameseText = "Giày", EnglishText = "Shoes", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Shoes.png", Status = true },
            new Word() { Id = 60, VietnameseText = "Quần short", EnglishText = "Shorts", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Short.png", Status = true },
            new Word() { Id = 61, VietnameseText = "Váy ngắn", EnglishText = "Skirt", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Skirt.png", Status = true },
            new Word() { Id = 62, VietnameseText = "Tất", EnglishText = "Socks", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Socks.png", Status = true },
            new Word() { Id = 63, VietnameseText = "Áo len", EnglishText = "Sweater", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Sweater.png", Status = true },
            new Word() { Id = 64, VietnameseText = "Đồ bơi", EnglishText = "Swimsuit", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Swimsuit.png", Status = true },
            new Word() { Id = 65, VietnameseText = "Áo phông", EnglishText = "T-Shirt", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/T-Shirt.png", Status = true },
            new Word() { Id = 66, VietnameseText = "Đồ lót", EnglishText = "Underwear", WordCategoryId = 5, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/clothes/Underwear.png", Status = true }
        );

        //color
        builder.Entity<Word>().HasData(
            new Word() { Id = 67, VietnameseText = "Màu đen", EnglishText = "Black", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Black.png", Status = true },
            new Word() { Id = 68, VietnameseText = "Màu xanh dương", EnglishText = "Blue", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Blue.png", Status = true },
            new Word() { Id = 69, VietnameseText = "Màu xanh lá", EnglishText = "Green", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Green.png", Status = true },
            new Word() { Id = 70, VietnameseText = "Màu cam", EnglishText = "Orange", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Orange.png", Status = true },
            new Word() { Id = 71, VietnameseText = "Màu hồng", EnglishText = "Pink", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Pink.png", Status = true },
            new Word() { Id = 72, VietnameseText = "Màu đỏ", EnglishText = "Red", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Red.png", Status = true },
            new Word() { Id = 73, VietnameseText = "Màu tím", EnglishText = "Violet", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Violet.png", Status = true },
            new Word() { Id = 74, VietnameseText = "Màu trắng", EnglishText = "White", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/White.png", Status = true },
            new Word() { Id = 75, VietnameseText = "Màu vàng", EnglishText = "Yellow", WordCategoryId = 6, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/color/Yellow.png", Status = true }
        );

        // feeling
        builder.Entity<Word>().HasData(
            new Word() { Id = 76, VietnameseText = "Đồng ý", EnglishText = "Agree", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Agree.png", Status = true },
            new Word() { Id = 77, VietnameseText = "Tức giận", EnglishText = "Angry", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Angry.png", Status = true },
            new Word() { Id = 78, VietnameseText = "Chán nản", EnglishText = "Bored", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Bored.png", Status = true },
            new Word() { Id = 79, VietnameseText = "Không đồng ý", EnglishText = "Disagree", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Disagree.png", Status = true },
            new Word() { Id = 80, VietnameseText = "Xấu hổ", EnglishText = "Embarrassing", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Embarrassing.png", Status = true },
            new Word() { Id = 81, VietnameseText = "Vui vẻ", EnglishText = "Happy", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Happy.png", Status = true },
            new Word() { Id = 82, VietnameseText = "Đói", EnglishText = "Hungry", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Hungry.png", Status = true },
            new Word() { Id = 83, VietnameseText = "Đau", EnglishText = "Hurt", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Hurt.png", Status = true },
            new Word() { Id = 84, VietnameseText = "Không hiểu", EnglishText = "Not understand", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Not understand.png", Status = true },
            new Word() { Id = 85, VietnameseText = "Buồn", EnglishText = "Sad", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Sad.png", Status = true },
            new Word() { Id = 86, VietnameseText = "Sợ hãi", EnglishText = "Scared", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Scared.png", Status = true },
            new Word() { Id = 87, VietnameseText = "Ốm", EnglishText = "Sick", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Sick.png", Status = true },
            new Word() { Id = 88, VietnameseText = "Buồn ngủ", EnglishText = "Sleepy", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Sleepy.png", Status = true },
            new Word() { Id = 89, VietnameseText = "Khát", EnglishText = "Thirsty", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Thirsty.png", Status = true },
            new Word() { Id = 90, VietnameseText = "Mệt mỏi", EnglishText = "Tired", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Tired.png", Status = true },
            new Word() { Id = 91, VietnameseText = "Nôn mửa", EnglishText = "Vomit", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Vomited.png", Status = true },
            new Word() { Id = 92, VietnameseText = "Ghê tởm", EnglishText = "Yucky", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Yucky.png", Status = true },
            new Word() { Id = 93, VietnameseText = "Ngon miệng", EnglishText = "Yummy", WordCategoryId = 7, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/feeling/Yummy.png", Status = true }
        );
        // food
        builder.Entity<Word>().HasData(
            new Word() { Id = 94, VietnameseText = "Bánh mì", EnglishText = "Bread", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Bread.png", Status = true },
            new Word() { Id = 95, VietnameseText = "Bánh kem", EnglishText = "Cake", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Cake.png", Status = true },
            new Word() { Id = 96, VietnameseText = "Sô cô la", EnglishText = "Chocolate", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Chocolate.png", Status = true },
            new Word() { Id = 97, VietnameseText = "Bánh quy", EnglishText = "Cookie", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Cookie.png", Status = true },
            new Word() { Id = 98, VietnameseText = "Kẹo cao su", EnglishText = "Gum", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Gum.png", Status = true },
            new Word() { Id = 99, VietnameseText = "Bánh hamburger", EnglishText = "Hamburger", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Hambuger.png", Status = true },
            new Word() { Id = 100, VietnameseText = "Kem", EnglishText = "Ice Cream", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/IceCream.png", Status = true },
            new Word() { Id = 101, VietnameseText = "Nước ép", EnglishText = "Juice", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Juice.png", Status = true },
            new Word() { Id = 102, VietnameseText = "Sữa", EnglishText = "Milk", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Milk.png", Status = true },
            new Word() { Id = 103, VietnameseText = "Pizza", EnglishText = "Pizza", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Pizza.png", Status = true },
            new Word() { Id = 104, VietnameseText = "Cơm", EnglishText = "Rice", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Rice.png", Status = true },
            new Word() { Id = 105, VietnameseText = "Bánh sandwich", EnglishText = "Sandwich", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Sandwich.png", Status = true },
            new Word() { Id = 106, VietnameseText = "Đồ ăn vặt", EnglishText = "Snack", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Snack.png", Status = true },
            new Word() { Id = 107, VietnameseText = "Súp", EnglishText = "Soup", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Soup.png", Status = true },
            new Word() { Id = 108, VietnameseText = "Mì Ý", EnglishText = "Spaghetti", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Spagetti.png", Status = true },
            new Word() { Id = 109, VietnameseText = "Trà", EnglishText = "Tea", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Tea.png", Status = true },
            new Word() { Id = 110, VietnameseText = "Nước", EnglishText = "Water", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Water.png", Status = true },
            new Word() { Id = 111, VietnameseText = "Sữa chua", EnglishText = "Yogurt", WordCategoryId = 8, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/food/Yogurt.png", Status = true }
        );

        // fruit
        builder.Entity<Word>().HasData(
            new Word() { Id = 112, VietnameseText = "Táo", EnglishText = "Apple", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Apple.png", Status = true },
            new Word() { Id = 113, VietnameseText = "Bơ", EnglishText = "Avocado", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Avocado.png", Status = true },
            new Word() { Id = 114, VietnameseText = "Chuối", EnglishText = "Banana", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Banana.png", Status = true },
            new Word() { Id = 115, VietnameseText = "Thanh long", EnglishText = "Dragon Fruit", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Dragon Fruit.png", Status = true },
            new Word() { Id = 116, VietnameseText = "Nho", EnglishText = "Grape", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Grape.png", Status = true },
            new Word() { Id = 117, VietnameseText = "Ổi", EnglishText = "Guava", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Guava.png", Status = true },
            new Word() { Id = 118, VietnameseText = "Kiwi", EnglishText = "Kiwi", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Kiwi.png", Status = true },
            new Word() { Id = 119, VietnameseText = "Cam", EnglishText = "Orange", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Orange.png", Status = true },
            new Word() { Id = 120, VietnameseText = "Đào", EnglishText = "Peach", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Peace.png", Status = true },
            new Word() { Id = 121, VietnameseText = "Dứa", EnglishText = "Pineapple", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Pineapple.png", Status = true },
            new Word() { Id = 122, VietnameseText = "Dâu tây", EnglishText = "Strawberry", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Strawberry.png", Status = true },
            new Word() { Id = 123, VietnameseText = "Dưa hấu", EnglishText = "Watermelon", WordCategoryId = 9, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/fruit/Watermelon.png", Status = true }
        );

        // number
        builder.Entity<Word>().HasData(
            new Word() { Id = 124, VietnameseText = "Một", EnglishText = "One", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/One.png", Status = true },
            new Word() { Id = 125, VietnameseText = "Hai", EnglishText = "Two", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Two.png", Status = true },
            new Word() { Id = 126, VietnameseText = "Ba", EnglishText = "Three", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Three.png", Status = true },
            new Word() { Id = 127, VietnameseText = "Bốn", EnglishText = "Four", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Four.png", Status = true },
            new Word() { Id = 128, VietnameseText = "Năm", EnglishText = "Five", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Five.png", Status = true },
            new Word() { Id = 129, VietnameseText = "Sáu", EnglishText = "Six", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Six.png", Status = true },
            new Word() { Id = 130, VietnameseText = "Bảy", EnglishText = "Seven", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Seven.png", Status = true },
            new Word() { Id = 131, VietnameseText = "Tám", EnglishText = "Eight", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Eight.png", Status = true },
            new Word() { Id = 132, VietnameseText = "Chín", EnglishText = "Nine", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Nine.png", Status = true },
            new Word() { Id = 133, VietnameseText = "Mười", EnglishText = "Ten", WordCategoryId = 10, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/number/Ten.png", Status = true }
        );

        // people
        builder.Entity<Word>().HasData(
            new Word() { Id = 134, VietnameseText = "Lại lần nữa", EnglishText = "Again", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Again.png", Status = true },
            new Word() { Id = 135, VietnameseText = "Em bé", EnglishText = "Baby", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Baby.png", Status = true },
            new Word() { Id = 136, VietnameseText = "Cậu bé", EnglishText = "Boy", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Boy.png", Status = true },
            new Word() { Id = 137, VietnameseText = "Bố", EnglishText = "Dad", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Dad.png", Status = true },
            new Word() { Id = 138, VietnameseText = "Mọi người", EnglishText = "Everyone", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Everyone.png", Status = true },
            new Word() { Id = 139, VietnameseText = "Cô bé", EnglishText = "Girl", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Girl.png", Status = true },
            new Word() { Id = 140, VietnameseText = "Bà", EnglishText = "Grandma", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Grandma.png", Status = true },
            new Word() { Id = 141, VietnameseText = "Ông", EnglishText = "Grandpa", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Grandpa.png", Status = true },
            new Word() { Id = 142, VietnameseText = "Bao nhiêu tiền", EnglishText = "How much", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/How much.png", Status = true },
            new Word() { Id = 143, VietnameseText = "Mẹ", EnglishText = "Mom", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Mom.png", Status = true },
            new Word() { Id = 144, VietnameseText = "Anh trai", EnglishText = "Older brother", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Older brother.png", Status = true },
            new Word() { Id = 145, VietnameseText = "Chị gái", EnglishText = "Older sister", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Older sister.png", Status = true },
            new Word() { Id = 146, VietnameseText = "Cái gì", EnglishText = "What", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/What.png", Status = true },
            new Word() { Id = 147, VietnameseText = "Khi nào", EnglishText = "When", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/When.png", Status = true },
            new Word() { Id = 148, VietnameseText = "Ở đâu", EnglishText = "Where", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Where.png", Status = true },
            new Word() { Id = 149, VietnameseText = "Cái nào", EnglishText = "Which one", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Which one.png", Status = true },
            new Word() { Id = 150, VietnameseText = "Ai", EnglishText = "Who", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Who.png", Status = true },
            new Word() { Id = 151, VietnameseText = "Tại sao", EnglishText = "Why", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Why.png", Status = true },
            new Word() { Id = 152, VietnameseText = "Em trai", EnglishText = "Younger brother", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Younger brother.png", Status = true },
            new Word() { Id = 153, VietnameseText = "Em gái", EnglishText = "Younger sister", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/Younger sister.png", Status = true },
            new Word() { Id = 154, VietnameseText = "Mấy giờ", EnglishText = "What time", WordCategoryId = 11, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/people/What time.png", Status = true }
        );

        // places
        builder.Entity<Word>().HasData(
            new Word() { Id = 155, VietnameseText = "Thủy cung", EnglishText = "Aquarium", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Aquarium.png", Status = true },
            new Word() { Id = 156, VietnameseText = "Phòng tắm", EnglishText = "Bathroom", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Bathroom.png", Status = true },
            new Word() { Id = 157, VietnameseText = "Phòng ngủ", EnglishText = "Bedroom", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Bedroom.png", Status = true },
            new Word() { Id = 158, VietnameseText = "Bệnh viện", EnglishText = "Hospital", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Hospital.png", Status = true },
            new Word() { Id = 159, VietnameseText = "Ngôi nhà", EnglishText = "House", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/House.png", Status = true },
            new Word() { Id = 160, VietnameseText = "Nhà bếp", EnglishText = "Kitchen", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Kitchen.png", Status = true },
            new Word() { Id = 161, VietnameseText = "Phòng khách", EnglishText = "Living room", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Living room.png", Status = true },
            new Word() { Id = 162, VietnameseText = "Công viên", EnglishText = "Park", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Park.png", Status = true },
            new Word() { Id = 163, VietnameseText = "Trường học", EnglishText = "School", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/School.png", Status = true },
            new Word() { Id = 164, VietnameseText = "Siêu thị", EnglishText = "Supermarket", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Supermarket.png", Status = true },
            new Word() { Id = 165, VietnameseText = "Nhà vệ sinh", EnglishText = "Toilet", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Toilet.png", Status = true },
            new Word() { Id = 166, VietnameseText = "Sở thú", EnglishText = "Zoo", WordCategoryId = 12, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/places/Zoo.png", Status = true }
        );

        // questions
        builder.Entity<Word>().HasData(
            new Word() { Id = 167, VietnameseText = "Lại lần nữa", EnglishText = "Again", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/Again.png", Status = true },
            new Word() { Id = 168, VietnameseText = "Bao nhiêu tiền", EnglishText = "How much", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/How much.png", Status = true },
            new Word() { Id = 169, VietnameseText = "Mấy giờ", EnglishText = "What time", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/WHat time.png", Status = true },
            new Word() { Id = 170, VietnameseText = "Cái gì", EnglishText = "What", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/What.png", Status = true },
            new Word() { Id = 171, VietnameseText = "Khi nào", EnglishText = "When", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/When.png", Status = true },
            new Word() { Id = 172, VietnameseText = "Ở đâu", EnglishText = "Where", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/Where.png", Status = true },
            new Word() { Id = 173, VietnameseText = "Cái nào", EnglishText = "Which one", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/Which one.png", Status = true },
            new Word() { Id = 174, VietnameseText = "Ai", EnglishText = "Who", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/Who.png", Status = true },
            new Word() { Id = 175, VietnameseText = "Tại sao", EnglishText = "Why", WordCategoryId = 13, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/questions/Why.png", Status = true }
        );

        // relations
        builder.Entity<Word>().HasData(
            new Word() { Id = 176, VietnameseText = "Ở trên", EnglishText = "Above", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Above.png", Status = true },
            new Word() { Id = 177, VietnameseText = "Phía sau", EnglishText = "Behind", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Behind.png", Status = true },
            new Word() { Id = 178, VietnameseText = "Ở dưới", EnglishText = "Below", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Below.png", Status = true },
            new Word() { Id = 179, VietnameseText = "Ít", EnglishText = "Few", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Few.png", Status = true },
            new Word() { Id = 180, VietnameseText = "Nặng", EnglishText = "Heavy", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Heavy.png", Status = true },
            new Word() { Id = 181, VietnameseText = "Cao", EnglishText = "High", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/High.png", Status = true },
            new Word() { Id = 182, VietnameseText = "Phía trước", EnglishText = "In front", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/In front.png", Status = true },
            new Word() { Id = 183, VietnameseText = "Ở trong", EnglishText = "Inside", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Inside.png", Status = true },
            new Word() { Id = 184, VietnameseText = "Lớn", EnglishText = "Large", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Large.png", Status = true },
            new Word() { Id = 185, VietnameseText = "Nhẹ", EnglishText = "Light", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Light.png", Status = true },
            new Word() { Id = 186, VietnameseText = "Dài", EnglishText = "Long", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Long.png", Status = true },
            new Word() { Id = 187, VietnameseText = "Thấp", EnglishText = "Low", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Low.png", Status = true },
            new Word() { Id = 188, VietnameseText = "Nhiều", EnglishText = "Many", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Many.png", Status = true },
            new Word() { Id = 189, VietnameseText = "Bên ngoài", EnglishText = "Outside", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Outside.png", Status = true },
            new Word() { Id = 190, VietnameseText = "Ngắn", EnglishText = "Short", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Short.png", Status = true },
            new Word() { Id = 191, VietnameseText = "Nhỏ", EnglishText = "Small", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Small.png", Status = true },
            new Word() { Id = 192, VietnameseText = "Dày", EnglishText = "Thick", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Thick.png", Status = true },
            new Word() { Id = 193, VietnameseText = "Mỏng", EnglishText = "Thin", WordCategoryId = 14, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/relations/Thin.png", Status = true }
        );

        // time
        builder.Entity<Word>().HasData(
            new Word() { Id = 194, VietnameseText = "Buổi chiều", EnglishText = "Afternoon", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Afternoon.png", Status = true },
            new Word() { Id = 195, VietnameseText = "Buổi tối", EnglishText = "Evening", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Evening.png", Status = true },
            new Word() { Id = 196, VietnameseText = "Buổi sáng", EnglishText = "Morning", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Morning.png", Status = true },
            new Word() { Id = 197, VietnameseText = "Ban đêm", EnglishText = "Night", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Night.png", Status = true },
            new Word() { Id = 198, VietnameseText = "Một giờ", EnglishText = "One Hour", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/One Hour.png", Status = true },
            new Word() { Id = 199, VietnameseText = "Mười phút", EnglishText = "Ten Minutes", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Ten Minutes.png", Status = true },
            new Word() { Id = 200, VietnameseText = "Ba mươi phút", EnglishText = "Thirty Minutes", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Thidy Minutes.png", Status = true },
            new Word() { Id = 201, VietnameseText = "Hôm nay", EnglishText = "Today", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Today.png", Status = true },
            new Word() { Id = 202, VietnameseText = "Ngày mai", EnglishText = "Tomorrow", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Tomorrow.png", Status = true },
            new Word() { Id = 203, VietnameseText = "Hôm qua", EnglishText = "Yesterday", WordCategoryId = 15, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/time/Yesterday.png", Status = true }
        );

        // toys
        builder.Entity<Word>().HasData(
            new Word() { Id = 204, VietnameseText = "Bóng", EnglishText = "Ball", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Ball.png", Status = true },
            new Word() { Id = 205, VietnameseText = "Bóng bay", EnglishText = "Balloon", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Ballon.png", Status = true },
            new Word() { Id = 206, VietnameseText = "Gấu bông", EnglishText = "Bear", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Bear.png", Status = true },
            new Word() { Id = 207, VietnameseText = "Khối xếp hình", EnglishText = "Block", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Block.png", Status = true },
            new Word() { Id = 208, VietnameseText = "Cờ bàn", EnglishText = "Board Game", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/BoardGame.png", Status = true },
            new Word() { Id = 209, VietnameseText = "Bong bóng xà phòng", EnglishText = "Bubble", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Bubble.png", Status = true },
            new Word() { Id = 210, VietnameseText = "Xe hơi", EnglishText = "Car", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Car.png", Status = true },
            new Word() { Id = 211, VietnameseText = "Đất nặn", EnglishText = "Clay", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Clay.png", Status = true },
            new Word() { Id = 212, VietnameseText = "Tô màu", EnglishText = "Coloring", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Coloring.png", Status = true },
            new Word() { Id = 213, VietnameseText = "Bút màu", EnglishText = "Crayon", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Crayon.png", Status = true },
            new Word() { Id = 214, VietnameseText = "Búp bê", EnglishText = "Doll", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Doll.png", Status = true },
            new Word() { Id = 215, VietnameseText = "Diều", EnglishText = "Kite", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Kite.png", Status = true },
            new Word() { Id = 216, VietnameseText = "Trò chơi ghép hình", EnglishText = "Puzzle", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Puzzle.png", Status = true },
            new Word() { Id = 217, VietnameseText = "Tivi", EnglishText = "Television", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Television.png", Status = true },
            new Word() { Id = 218, VietnameseText = "Đồ chơi", EnglishText = "Toy", WordCategoryId = 16, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/toys/Toy.png", Status = true }
        );

        // vehicles
        builder.Entity<Word>().HasData(
            new Word() { Id = 219, VietnameseText = "Máy bay", EnglishText = "Airplane", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Airplane.png", Status = true },
            new Word() { Id = 220, VietnameseText = "Xe đạp", EnglishText = "Bike", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Bike.png", Status = true },
            new Word() { Id = 221, VietnameseText = "Xe buýt", EnglishText = "Bus", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Bus.png", Status = true },
            new Word() { Id = 222, VietnameseText = "Xe hơi", EnglishText = "Car", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Car.png", Status = true },
            new Word() { Id = 223, VietnameseText = "Xe máy", EnglishText = "Motorbike", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Motorbike.png", Status = true },
            new Word() { Id = 224, VietnameseText = "Tàu thủy", EnglishText = "Ship", WordCategoryId = 17, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/vehicles/Ship.png", Status = true }
        );

        // want
        builder.Entity<Word>().HasData(
            new Word() { Id = 225, VietnameseText = "Ôm", EnglishText = "Hug", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/Hug.png", Status = true },
            new Word() { Id = 226, VietnameseText = "Con không muốn", EnglishText = "I don't want", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/I don't want.png", Status = true },
            new Word() { Id = 227, VietnameseText = "Con muốn", EnglishText = "I want", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/I want.png", Status = true },
            new Word() { Id = 228, VietnameseText = "Không", EnglishText = "No", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/No.png", Status = true },
            new Word() { Id = 229, VietnameseText = "Xin lỗi", EnglishText = "Sorry", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/Sorry.png", Status = true },
            new Word() { Id = 230, VietnameseText = "Cảm ơn", EnglishText = "Thank you", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/Thank you.png", Status = true },
            new Word() { Id = 231, VietnameseText = "Có", EnglishText = "Yes", WordCategoryId = 18, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "images/word/want/Yes.png", Status = true }
        );

        builder.Entity<Game>().HasData(
            new Game() { Id = 1, Name = "Dot Connection", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
            new Game() { Id = 2, Name = "Coloring", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
            new Game() { Id = 3, Name = "AAC", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
            new Game() { Id = 4, Name = "Emotion Selection", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
            new Game() { Id = 5, Name = "Fruit Drop", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
            new Game() { Id = 6, Name = "Tower Build", Description = "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque. (Comming Soon!)", VideoUrl = "https://www.youtube.com/watch?v=ynJ_nraLqU4" }
        );
    }

}