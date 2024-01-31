namespace GADistribuidora.Infraestructure.ProgramConfigurations
{
    public static class AddCorsExtension
    {
        public static void AddCors(this WebApplicationBuilder builder) 
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}
