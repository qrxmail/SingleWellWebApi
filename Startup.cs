using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SingleWellWebApi.Models;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;

namespace SingleWellWebApi
{
    public class Startup
    {
        private readonly string AllowSpecificOrigin = "AllowSpecificOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { options.EnableEndpointRouting = false; });

            // ʹ��PostgreSql���ݿ�
            services.AddDbContext<SingleWellWebContext>(option => option.UseNpgsql(Configuration.GetConnectionString("PostgreSql")));
            // ʹ��MySql���ݿ�
            //services.AddDbContext<SingleWellWebContext>(option => option.UseMySql(Configuration.GetConnectionString("MySql")));

            // ���ʱ����8Сʱ������
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                opt.JsonSerializerOptions.Converters.Add(new JsonDateTimeConvert());

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #region ����
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigin, builder => { builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); });
            });
            #endregion

            // ����session
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(60 * 120);//����session�Ĺ���ʱ��
                options.Cookie.HttpOnly = true;//���������������ͨ��js��ø�cookie��ֵ
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            //HttpContextAccessor Ĭ��ʵ���������˷���HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app)
        {
            //ʹ��session
            app.UseSession();

            app.UseRouting();
            //CORS �м����������Ϊ�ڶ� UseRouting �� UseEndpoints�ĵ���֮��ִ�С� ���ò���ȷ�������м��ֹͣ�������С�
            app.UseCors(AllowSpecificOrigin);
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(defaultFilesOptions);

            StaticFileOptions staticFileOptions = new StaticFileOptions();
            staticFileOptions.FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(@"D:\webapi\NFCInspectServer\wwwroot");
            app.UseStaticFiles(staticFileOptions);//������̬�ļ�
        }

    }

    /// <summary>
    /// ��ǰ�˴�������ʱ��ת��Ϊ����ʱ�䣨���ʱ����8Сʱ�����⣩
    /// </summary>
    public class JsonDateTimeConvert : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var paramString = reader.GetString();

            var localDateTime = Convert.ToDateTime(paramString);

            return localDateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
