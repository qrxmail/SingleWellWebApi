using controlCenterWebApi.Model;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OilTankHMI.Model;
using RJCGrpcService;

namespace SingleWellWebApi.Controllers.BaseInfo
{
    [Route("api")]
    [ApiController]
    public class StationControlController : ControllerBase
    {
        const string GrpcServiceUrl = "https://localhost:5001";

        // 获取站点数据
        [Route("getStationData")]
        [HttpGet]
        public IActionResult Get()
        {
            using var channel = GrpcChannel.ForAddress(GrpcServiceUrl);
            var client = new Greeter.GreeterClient(channel);
            // 获取PLC信息
            var reply = client.SayHello(new HelloRequest { Name = "LineZero" });
            var plcModel = JsonConvert.DeserializeObject<ST_PLCData>(reply.Message);
            // 将PLC模型转换为站点模型
            var stationModel = new StationModel(plcModel);
            return new OkObjectResult(stationModel);
        }

        // 站点控制
        [Route("stationControl")]
        [HttpPost]
        public void Post([FromBody] StationControlModel model)
        {
            using var channel = GrpcChannel.ForAddress(GrpcServiceUrl);
            var client = new Greeter.GreeterClient(channel);
            // 发送指令
            var reply = client.WriteStation(new ControlModel { Target = model.target, Action = model.action });
        }
    }

}
