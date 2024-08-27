using AutoMapper;
using DevApi.ViewModels;
using DevBusiness.Interfaces;
using DevBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepository fornecedorRepository,
                                    IFornecedorService fornecedorService,
                                    IMapper mapper,
                                    INotificador notificador,
                                    IEnderecoRepository enderecoRepository) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> GetAll()
        {
            var fornecedor = await ObterTodos();

            return Ok(fornecedor);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> GetById(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Post(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomResponse(fornecedorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Put(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            return CustomResponse(fornecedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return NotFound();

            await _fornecedorService.Remover(id);

            return CustomResponse();
        }

        [HttpGet("obter-endereco/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> GetEnderecoById(Guid id)
        {
            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
            return Ok(enderecoViewModel);
        }

        [HttpPut("atualizar-endereoco/{id:guid}")]
        public async Task<ActionResult> PutEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id) return CustomResponse();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        [NonAction]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
        }

        [NonAction]
        public async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        [NonAction]
        public async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}
