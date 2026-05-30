using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ML;

namespace BL;

public class LoginBL
{
    public static ML.Result GetAll()
    {
        ML.Result result = new ML.Result();

        try
        {
            using Context context = new();

            var logins = context.Logins
                .FromSqlRaw("EXEC SP_GetAllLogins")
                .ToList();

            result.Objects = logins
                .Cast<object>()
                .ToList();

            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    public static ML.Result Add(ML.Login login)
    {
        ML.Result result = new ML.Result();

        try
        {
            using Context context = new();

            context.Database.ExecuteSqlRaw(
                "EXEC SP_AddLogin @User_id, @Extension, @TipoMov, @Fecha",
                new SqlParameter("@User_id", login.User_id),
                new SqlParameter("@Extension", login.Extension),
                new SqlParameter("@TipoMov", login.TipoMov),
                new SqlParameter("@Fecha", login.Fecha));

            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    public static ML.Result Update(ML.Login login)
    {
        ML.Result result = new ML.Result();

        try
        {
            using Context context = new();

            context.Database.ExecuteSqlRaw(
                "EXEC SP_UpdateLogin @Id,@Extension,@TipoMov,@Fecha",
                new SqlParameter("@Id", login.Id),
                new SqlParameter("@Extension", login.Extension),
                new SqlParameter("@TipoMov", login.TipoMov),
                new SqlParameter("@Fecha", login.Fecha));

            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    public static ML.Result Delete(int id)
    {
        ML.Result result = new ML.Result();

        try
        {
            using Context context = new();

            context.Database.ExecuteSqlRaw(
                "EXEC SP_DeleteLogin @Id",
                new SqlParameter("@Id", id));

            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    public static ML.Result GetWorkedHoursReport()
    {
        ML.Result result = new();

        try
        {
            using Context context = new();

            var report = context.WorkedHoursReports
                .FromSqlRaw("EXEC SP_GetWorkedHoursReport")
                .ToList();

            result.Objects = report
                .Cast<object>()
                .ToList();

            result.Correct = true;
        }
        catch (Exception ex)
        {
            result.Correct = false;
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

}