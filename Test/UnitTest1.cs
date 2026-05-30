using BL;
using ML;
using Xunit;

namespace Test
{
    public class LoginTests
    {
        [Fact]
        public void Add_UserNotExists_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 999999,
                Extension = 100,
                TipoMov = 1,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
            Assert.Contains("usuario no existe", result.ErrorMessage.ToLower());
        }

        [Fact]
        public void Add_TipoMovInvalid_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 1,
                Extension = 100,
                TipoMov = 5,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
            Assert.Contains("tipomov", result.ErrorMessage.ToLower());
        }

        [Fact]
        public void Add_FutureDate_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 1,
                Extension = 100,
                TipoMov = 1,
                Fecha = DateTime.Now.AddDays(1)
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
            Assert.Contains("fecha", result.ErrorMessage.ToLower());
        }

        [Fact]
        public void Add_FirstMovementLogout_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 90, 
                Extension = 100,
                TipoMov = 0,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
        }

        [Fact]
        public void Add_ConsecutiveLogin_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 1,
                Extension = 100,
                TipoMov = 1,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
        }

        [Fact]
        public void Add_ConsecutiveLogout_ReturnFalse()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 2,
                Extension = 100,
                TipoMov = 0,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.False(result.Correct);
        }

        [Fact]
        public void Add_LoginCorrect_ReturnTrue()
        {
            ML.Login login = new ML.Login()
            {
                User_id = 71,
                Extension = 100,
                TipoMov = 1,
                Fecha = DateTime.Now
            };

            ML.Result result = BL.LoginBL.Add(login);

            Assert.True(result.Correct);
        }
    }
}