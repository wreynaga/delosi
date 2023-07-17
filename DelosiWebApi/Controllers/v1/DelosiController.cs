using DelosiWebApi.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DelosiWebApi.Controllers.v1
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DelosiController : Controller
    {
        [HttpPost("Rotate")]
        public ActionResult<int[][]> Index([FromBody] int[][] matriz)
        {
            int longitud = matriz.Length;
            int[][] nuevaMatriz = new int[longitud][];

            for (int i = 0; i < longitud; i++) { nuevaMatriz[i] = new int[longitud]; }
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    nuevaMatriz[i][j] = matriz[j][longitud - i - 1];
                }
            }
            return nuevaMatriz;
        }
    }
}
