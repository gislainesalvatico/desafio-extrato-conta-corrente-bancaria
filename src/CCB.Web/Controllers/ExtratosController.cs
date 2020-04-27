using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CCB.Service.Services;
using CCB.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CCB.Web.Controllers
{
    public class ExtratosController : Controller
    {
        private BaseService<Domain.Model.Extrato> _service = new BaseService<Domain.Model.Extrato>();
        private readonly IMapper _mapper;
        private const string SaldoInsuficiente = "Saldo insuficiente";

        public ExtratosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var extrato = _mapper.Map<IEnumerable<Models.Extrato>>(_service.Get());
            return View(extrato);
        }

        public ActionResult Deposito()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Deposito(Models.Extrato extrato)
        {
            extrato.Tipo = 1;

            if (ModelState.IsValid)
            {
                var extratoDomain = _mapper.Map<Domain.Model.Extrato>(extrato);
                _service.Insert<ExtratoValidator>(extratoDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(extrato);
        }
        
        public ActionResult Retirada()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Retirada(Models.Extrato extrato )
        {
            extrato.Tipo = 2;

            var listExtrato = _mapper.Map<IEnumerable<Models.Extrato>>(_service.Get()).ToList();
           
            if (extrato.SaldoInsuficiente(extrato.Saldo(listExtrato), extrato.Valor))
                ModelState.AddModelError(nameof(extrato.Valor), SaldoInsuficiente);

            if (ModelState.IsValid)
            {
                var extratoDomain = _mapper.Map<Domain.Model.Extrato>(extrato);
                _service.Insert<ExtratoValidator>(extratoDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(extrato);
        }

        public ActionResult Pagamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pagamento(Models.Extrato extrato)
        {
            extrato.Tipo = 2;

            var listExtrato = _mapper.Map<IEnumerable<Models.Extrato>>(_service.Get()).ToList();

            if (extrato.SaldoInsuficiente(extrato.Saldo(listExtrato), extrato.Valor))
                ModelState.AddModelError(nameof(extrato.Valor), SaldoInsuficiente);

            if (ModelState.IsValid)
            {
                var extratoDomain = _mapper.Map<Domain.Model.Extrato>(extrato);
                _service.Insert<ExtratoValidator>(extratoDomain);

                return RedirectToAction(nameof(Index));
            }

            return View(extrato);
        }
    }
}