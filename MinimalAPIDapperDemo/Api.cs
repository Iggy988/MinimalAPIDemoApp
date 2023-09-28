using DataAccess.Data;
using DataAccess.Models;

namespace MinimalAPIDapperDemo;

public static class Api
{
    //extension method
    public static void ConfigureSomeApi(this WebApplication app)
    {
        //All of my API configuration
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
    }
    private static async Task<IResult> GetUsers(IUserData userData)
    {
        try
        {
            return Results.Ok(await userData.GetUsers());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    //nisu expose izvan Api class
    private static async Task<IResult> GetUser(int id, IUserData userData)
    {
        try
        {
            var result = await userData.GetUser(id);
            if (result == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel userModel, IUserData data)
    {
        try
        {
            await data.InsertUser(userModel);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


}
