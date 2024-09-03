using AutoMapper;
using DevApi.ViewModels;
using DevBusiness.Interfaces;
using DevBusiness.Models;
using DevData.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(INotificador notificador,
                                  IProdutoService produtoService,
                                  IProdutoRepository produtoRepository,
                                  IMapper mapper) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> GetAll()
        {
            var produtoViewModel = await ObterTodos();
            
            return Ok(produtoViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> GetById(Guid id)
        {
            var produtoViewModel = await ObterPorId(id);

            if(produtoViewModel == null) return NotFound();

            return Ok(produtoViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Post(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse();

            var imageNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;

            if (!UploadArquivo(produtoViewModel.ImagemUpload, imageNome)) return CustomResponse();

            produtoViewModel.Imagem = imageNome;

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Put(Guid id, ProdutoViewModel produtoViewModel)
        {
            if(id != produtoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Delete(Guid id)
        {
            var produtoViewModel = await ObterPorId(id);

            if( produtoViewModel == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(produtoViewModel);
        }

        [NonAction]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [NonAction]
        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        [NonAction]
        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para o poduto");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);
          
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
