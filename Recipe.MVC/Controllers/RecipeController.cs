using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipe.Application.Comment.Commands.CreateComment;
using Recipe.Application.Comment.Queries.GetAllCommentsByEncodedTitle;
using Recipe.Application.Recipe.Commands.CreateRecipe;
using Recipe.Application.Recipe.Commands.DeleteRecipeCommand;
using Recipe.Application.Recipe.Commands.EditRecipe;
using Recipe.Application.Recipe.Queries.GetAllRecipes;
using Recipe.Application.Recipe.Queries.GetRecipeByEncodedTitle;
using Recipe.Application.Step.Commands.CreateStep;
using Recipe.Application.Step.Queries.GetAllStepsByEncodedTitle;

namespace Recipe.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RecipeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper=mapper;
        }

        [Authorize]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe(CreateRecipeCommand createRecipeCommand)
        {
            await _mediator.Send(createRecipeCommand);
            this.SetNotification("success", "Pomyslnie utworzono przepis");
            return RedirectToAction("Index","Recipe");
        }

        public async Task <IActionResult> Index()
        {
            var dtos = await _mediator.Send(new GetAllRecipesQuery());
            return View(dtos);
        }

        [HttpDelete]
        [Route("Recipe/{encodedTitle}/Delete")]
        public async Task<IActionResult> Delete(string encodedTitle)
        {
            await _mediator.Send(new DeleteRecipeCommand(encodedTitle));
            return Ok();
        }

        [Route("Recipe/{encodedTitle}/Details")]
        public async Task <IActionResult> Details(string encodedTitle)
        {
            var dtos = await _mediator.Send(new GetRecipeByEncodedTitleQuery(encodedTitle));
            return View(dtos);
        }
        
        [Route("Recipe/{encodedTitle}/Edit")]
        public async Task<IActionResult> Edit(string encodedTitle)
        {
            var recipedto = await _mediator.Send(new GetRecipeByEncodedTitleQuery(encodedTitle));
            if(!recipedto.IsEditable) 
            {
                return RedirectToAction("Index", "Recipe");
            }
            var editCommand = _mapper.Map<EditRecipeCommand>(recipedto);
            return View(editCommand);
        }

        [HttpPost]
        [Route("Recipe/{encodedTitle}/Edit")]
        public async Task<IActionResult> Edit (EditRecipeCommand editRecipeCommand)
        {

            await _mediator.Send(editRecipeCommand);
            return RedirectToAction("Index", "Recipe");
        }

        [HttpPost]
        public async Task <IActionResult> CreateStep (CreateStepCommand createStepCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _mediator.Send(createStepCommand);
            return Ok();
        }



        [HttpGet]
        [Route("Recipe/{recipeEncodedTitle}/Steps")]
        public async Task <IActionResult> GetSteps(string recipeEncodedTitle)
        {
            var dtos = await _mediator.Send(new GetAllStepsByEncodedTitleQuery(recipeEncodedTitle));
            return Ok(dtos);
        }

        [Authorize]
        [HttpPost]
        public async Task <IActionResult> CreateComment(CreateCommentCommand createCommentCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            await _mediator.Send(createCommentCommand);
            return Ok();
        }

        [HttpGet]
        [Route("Recipe/{recipeEncodedTitle}/Comments")]
        public async Task<IActionResult> GetComments(string recipeEncodedTitle)
        {
            var dtos = await _mediator.Send(new GetAllCommentsByEncodedTitleQuery(recipeEncodedTitle));
            return Ok(dtos);
        }
    }
}
