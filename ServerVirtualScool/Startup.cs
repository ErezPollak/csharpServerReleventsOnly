
using DAL.Teachers;
using DAL.Students;
using DAL.CourseDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DAL.LearningFiles;
using DAL.PreparedLessons;

using DAL.Group;

using DAL.CourseToClassDAL;
using Entities.Entities;
using DAL.ScheduleDAL;
using DAL.PresenceInLessonsDAL;
using DAL.ScheduleHoursDAL;
using DAL.A_DTO;
using DAL.CourseTestsDTO;
using DAL.SendMailOfPrencipalDTO;

using DAL.CuorsessViewDTO;
using BLL;

namespace ServerVirtualScool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            services.AddDbContext<My_Virtua_lSchoolContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IStudents, Students>();
            services.AddScoped<ITeachers, Teachers>();
            services.AddScoped<ICrousesDAL, CoursesDAL>();
            services.AddScoped<ILearningFiles, LearningFiless>();
            services.AddScoped<IPreparedLessons, PreparedLessonss>();
            services.AddScoped<IGroup, DAL.Group.Groupss>();
            services.AddScoped<ICourseToClassDAL, CourseToClassesDAL>();
            services.AddScoped<IScheduleDAL, SchedulesDAL>();
            services.AddScoped<IPresenceInLessonsDAL, PresenceInLessonssDAL>();
            services.AddScoped<IScheduleHoursDAL, ScheduleHourssDAL>();
            services.AddScoped<ICourseTestDTO, CourseTestsDTO>();
            services.AddScoped<ISendMailDTODAL, SendMailDTODAL>();
            services.AddScoped<IClassCuorsesViewDTO, ClassCuorsesViewDTO>();
            services.AddTransient<SendMailDTOBLL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();
                app.UseCors(MyAllowSpecificOrigins);
                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    //endpoints.MapControllerRoute(
                    //    name: "default",
                    //    pattern: "{controller}/{action=Index}{id?}");
                    endpoints.MapControllers();
                });
            }
            catch(Exception ex)
            {

            }
        }
    }
}
