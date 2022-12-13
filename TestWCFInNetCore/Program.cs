using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;

using TestWCFInNetCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
         
builder.Services
    .AddServiceModelServices()
    .AddServiceModelMetadata()
    .AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

//app.UseServiceModel(serviceBuilder =>
//{
//    var binding = new BasicHttpBinding();

//    serviceBuilder
//        .AddService<EchoService>()
//    // Add a BasicHttpBinding at a specific endpoint
//    .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp")
//    // Add a WSHttpBinding with Transport Security for TLS
//    .AddServiceEndpoint<EchoService, IEchoService>(new WSHttpBinding(SecurityMode.Transport), "/EchoService/WSHttps");

//});

app.UseServiceModel(bld =>
{
    bld.AddService<EchoService>();
    bld.AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(
        BasicHttpSecurityMode.Transport), "/EchoService/basichttp");
    var mb = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    mb.HttpsGetEnabled = true;
});

////app.UseServiceModel(builder =>
////{
////    builder.AddService(serviceOptions => { })
////    // Add a BasicHttpBinding at a specific endpoint
////    .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp")
////    // Add a WSHttpBinding with Transport Security for TLS
////    .AddServiceEndpoint<EchoService, IEchoService>(new WSHttpBinding(SecurityMode.Transport), "/EchoService/WSHttps");
////});              

////var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
////serviceMetadataBehavior.HttpGetEnabled = true;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
                              
app.Run();
