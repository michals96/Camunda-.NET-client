using Camunda.Api.Client;
using poc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICamundaService, CamundaService>();
builder.Services.AddSingleton<CamundaClient>(sp =>
{
    HttpClient httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri("http://localhost:8080/engine-rest");
    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic ZGVtbzpkZW1v");
    CamundaClient camunda = CamundaClient.Create(httpClient);
    return camunda;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
