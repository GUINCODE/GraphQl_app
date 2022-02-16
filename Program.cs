using GraphQl_app.Data;
using GraphQl_app.GraphQL_Types;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddMutationType<MutationType>()
            .AddSubscriptionType<SubscriptionType>()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();
app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL(); //permet de donner une route par defaut "/graphql" pour ouvrire l'ide Banana cake pop
app.UseGraphQLVoyager("/voyager");
app.UseGraphQLAltair("/altaire");
app.UseGraphQLGraphiQL("/graphiql");
app.Run();
