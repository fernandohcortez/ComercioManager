using System;
using System.Threading.Tasks;
using CM.Core;
using CM.Domain.BLLs;
using CM.WebApi.Controllers.Base;
using CM.WebApi.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace CM.WebApi.Controllers
{
    //[RoutePrefix("api/Usuario")]
    public class UsuarioController : ControllerBase<UsuarioDTO, UsuarioBLL, string>
    {
        //[Route("GetUsuarioCorrente")]
        //public UsuarioDTO GetUsuarioCorrente()
        //{
        //    return BLL.Get(RequestContext.Principal.Identity.GetUserId());
        //}

        //public override async Task<UsuarioDTO> Post(UsuarioDTO usuarioDto)
        //{
        //    var registerBindingModel = new RegisterBindingModel
        //    {
        //        Email = usuarioDto.Email,
        //        Password = usuarioDto.Password,
        //        ConfirmPassword = usuarioDto.ConfirmPassword
        //    };

        //    return await BLL.AddAsync(usuarioDto);
        //}

        //public override UsuarioDTO Post(UsuarioDTO dto)
        //{
        //    var registerBindingModel = new RegisterBindingModel
        //    {
        //        Email = dto.Email,
        //        Password = dto.Password,
        //        ConfirmPassword = dto.ConfirmPassword
        //    };

        //    var accountController = new AccountController();
        //    var resultRegister = accountController.Register(registerBindingModel).ContinueWith(m =>
        //    {
        //        if (m.Result == Ok())
        //        {
        //            var teste = accountController.GetUserInfo();
        //        }

        //        return base.Post(dto);
        //    });

        //    resultRegister.Wait();
        //}
    }
}