using AutoMapper;
using Newtonsoft.Json;
using PesquisaComAjax.Application.Interfaces;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PesquisaComAjax.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IAppProdutoService _serviceProdutoApp;

        public ProdutosController(IAppProdutoService serviceProdutoApp)
        {
            _serviceProdutoApp = serviceProdutoApp;
        }

        // GET: Produtos
        [HttpGet]
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_serviceProdutoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int id)
        {
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(_serviceProdutoApp.GetById(id));
            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [Route("Create")]
        [HttpPost]
        public JsonResult Create(ProdutoViewModel produto, HttpPostedFileBase fotoUpload)
        {
            if (!ModelState.IsValid)
            {
                var erro = JsonConvert.SerializeObject(ModelState.Values.Where(x => x.Errors.Count > 0));

                return Json(erro, JsonRequestBehavior.AllowGet);
            }

            return Json(JsonConvert.SerializeObject("Cadastro efetuado com sucesso!"), JsonRequestBehavior.AllowGet);
        }

        //// POST: Produtos/Create
        //[Route("Create")]
        //[HttpPost]
        //public ActionResult Create(ProdutoViewModel produto, HttpPostedFileBase fotoUpload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (fotoUpload != null && fotoUpload.ContentLength > 0)
        //        {
        //            if (Application.Helpers.IsValid.IsImage(fotoUpload))
        //            {
        //                produto.Imagem = Application.Helpers.IsValid.ConvertToBytes(fotoUpload);

        //                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
        //                _serviceProdutoApp.Add(produtoDomain);

        //                return RedirectToAction("Index");

        //            }
        //            else
        //            {
        //                ModelState.AddModelError("ImagemFile", "Formato não aceito");
        //                return View(produto);

        //            }
        //        }

        //    }
        //    return View(produto);

        //}

        public ActionResult Pesquisar(string Pesquisar = "")
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_serviceProdutoApp.PesquisarPorNome(Pesquisar));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Produtos", produtoViewModel);
            }

            return View("Index", produtoViewModel);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _serviceProdutoApp.GetById(id);
            var produtoDomain = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoDomain);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _serviceProdutoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var produto = _serviceProdutoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var produtoViewModel = _serviceProdutoApp.GetById(id);
            _serviceProdutoApp.Remove(produtoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Portfolio()
        {
            var produtoView = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_serviceProdutoApp.GetAll());

            return View(produtoView);
        }

        [HttpGet]
        public ActionResult ExibirProduto(int id)
        {
            return View();
        }

        public byte[] GetImageFromDataBase()
        {
            return _serviceProdutoApp.ObterImagens();
        }
    }
}