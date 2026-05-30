using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = BL.LoginBL.GetAll();

            return result.Correct
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ML.Login login)
        {
            var result = BL.LoginBL.Add(login);

            return result.Correct
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ML.Login login)
        {
            login.Id = id;

            var result = BL.LoginBL.Update(login);

            return result.Correct
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = BL.LoginBL.Delete(id);

            return result.Correct
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("csv")]
        public IActionResult GenerateCsv()
        {
            var result = BL.LoginBL.GetWorkedHoursReport();

            if (!result.Correct)
                return BadRequest(result);

            StringBuilder csv = new();

            csv.AppendLine(
                "LoginName,NombreCompleto,AreaName,TotalHorasTrabajadas");

            foreach (ML.WorkedHoursReport item in result.Objects)
            {
                csv.AppendLine(
                    $"{item.Login}," +
                    $"{item.NombreCompleto}," +
                    $"{item.AreaName}," +
                    $"{item.TotalHorasTrabajadas}");
            }

            byte[] bytes = Encoding.UTF8.GetBytes(csv.ToString());

            return File(
                bytes,
                "text/csv",
                "ReporteHorasTrabajadas.csv");
        }
    }
}
