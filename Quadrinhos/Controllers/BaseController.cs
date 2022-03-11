using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quadrinhos.Domain.Conts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Domain.Result;
using Quadrinhos.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Quadrinhos.Controllers
{
    [ApiController]
    public class BaseController<TModel, TIdType> : ControllerBase
        where TModel : class, IModel<TIdType>
    {
        public Func<IActionResult> BeforeInsert;
        public Func<IActionResult> AfterInsert;

        public Func<IActionResult> BeforeUpdate;
        public Func<IActionResult> AfterUpdate;

        public Func<IActionResult> BeforeDelete;
        public Func<IActionResult> AfterDelete;

        protected readonly IServiceBase<TModel, TIdType> _service;

        protected TModel _model;
        protected TIdType _id;

        public BaseController(IServiceBase<TModel, TIdType> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IActionResult Get([FromQuery] int limit = 0, int offset = 0)
        {
            var result = new ListResultBase<IList<TModel>>();

            try
            {
                var list = new List<TModel>();

                var query = _service.Get().AsNoTracking();

                result.Count = query.Count();

                if (limit != 0 || offset != 0)
                {
                    query = query
                    .Skip(offset)
                    .Take(limit).AsQueryable();
                }

                list = query.ToList();

                result.Data = list;

                result.Success = true;
                result.Message = "Consulta executada com sucesso";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocorreu um erro ao recuperar as informações.";
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(TIdType id)
        {
            var result = new ListResultBase<IList<TModel>>();

            try
            {
                var query = _service.Get(id).AsNoTracking();

                result.Data = query.ToList();

                result.Success = true;
                result.Message = "Consulta executada com sucesso";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocorreu um erro ao recuperar as informações.";
            }

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TModel model)
        {
            _model = model;

            var result = new ResultBase<TModel>
            {
                Data = model
            };

            var validateResult = this.ValidateModelState<TModel>(Mensagens.ErroInserir);

            if (validateResult != null)
                return Ok(validateResult);

            var res = BeforeInsert?.Invoke();

            if (res != null)
                return res;

            if (await _service.Insert(model) > 0)
            {
                AfterInsert?.Invoke();

                result.Message = Mensagens.SucessoInserir;

                return Ok(result);
            }

            result.Success = false;
            result.Message = Mensagens.ErroInserir;

            AfterInsert?.Invoke();

            return Ok(result);
        }

        [HttpPut()]
        public virtual async Task<IActionResult> Put(TModel model)
        {
            _model = model;

            var result = new ResultBase<TModel>
            {
                Data = model
            };

            var validateResult = this.ValidateModelState<TModel>(Mensagens.ErroAtualizar);

            if (validateResult != null)
                return validateResult;

            BeforeUpdate?.Invoke();

            if (await _service.Update(model) > 0)
            {
                result.Message = Mensagens.SucessoAtualizar;

                AfterUpdate?.Invoke();

                return Ok(result);
            }

            result.Message = Mensagens.ErroAtualizar;

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TIdType id)
        {
            var result = new ResultBase<TModel>();

            try
            {
                _id = id;

                var res = BeforeDelete?.Invoke();

                if (res != null)
                    return res;

                var resultado = await _service.Delete(id);

                if (resultado > 0)
                {
                    result.Message = Mensagens.SucessoApagar;
                }

                if (resultado == 0)
                {
                    result.Message = Mensagens.ErroApagar;
                    result.Success = false;
                }

                if (resultado == -1)
                {
                    result.Success = false;
                    result.Message = Mensagens.RegistroNaoEncontrado;
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = Mensagens.ErroApagar;
                result.Success = false;

                return Ok(result);
            }

        }
    }
}
