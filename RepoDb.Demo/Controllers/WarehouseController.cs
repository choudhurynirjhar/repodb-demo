using Microsoft.AspNetCore.Mvc;

namespace RepoDb.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseRepository warehouseRepository;
        private readonly IWarehouseObjectRepo warehouseObjectRepo;
        private readonly IWarehouseInlineRepo warehouseInlineRepo;
        private readonly IWarehouseProcedureRepo warehouseProcedureRepo;
        private readonly IWarehouseProvider warehouseProvider;
        private readonly IWareHouseUpdator wareHouseUpdator;
        private readonly IWareHouseDeletor wareHouseDeletor;

        public WarehouseController(WarehouseRepository warehouseRepository,
            IWarehouseObjectRepo warehouseObjectRepo,
            IWarehouseInlineRepo warehouseInlineRepo,
            IWarehouseProcedureRepo warehouseProcedureRepo,
            IWarehouseProvider warehouseProvider,
            IWareHouseUpdator wareHouseUpdator,
            IWareHouseDeletor wareHouseDeletor)
        {
            this.warehouseRepository = warehouseRepository;
            this.warehouseObjectRepo = warehouseObjectRepo;
            this.warehouseInlineRepo = warehouseInlineRepo;
            this.warehouseProcedureRepo = warehouseProcedureRepo;
            this.warehouseProvider = warehouseProvider;
            this.wareHouseUpdator = wareHouseUpdator;
            this.wareHouseDeletor = wareHouseDeletor;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(warehouseProvider.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(warehouseProvider.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Warehouse warehouse)
        {
            wareHouseUpdator.Update(warehouse);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            wareHouseDeletor.Delete(id);
            return Ok();
        }
    }
}
