﻿using AgendaDeTarefasAtt.Models;
using AgendaDeTarefasAtt.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaDeTarefasAtt.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

      public TarefaController(ITarefaRepositorio tarefaRepositorio)
       {
            _tarefaRepositorio = tarefaRepositorio;
       }

        public IActionResult Index()
        {
            List<TarefaModel> tarefas = _tarefaRepositorio.BuscarTodos();

            return View(tarefas);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Apagar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _tarefaRepositorio.Deletar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa apagada com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu sua tarefa!";
                }

                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu sua tarefa, mais detahes do erro: {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(TarefaModel tarefa)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Adicionar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa cadastrada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(tarefa);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua tarefa, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
       
        [HttpPost]
        public IActionResult Alterar(TarefaModel tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Atualizar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa alterada com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", tarefa);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar sua tarefa, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}