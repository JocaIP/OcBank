using Microsoft.Extensions.Configuration;
using OcBank.Application.UseCases.Login;

public class LoginUseCase
{
    private readonly IUsuarioRepositorio _repositorio;
    private readonly TokenService _tokenService;
    private readonly IConfiguration _config;

    public LoginUseCase(
        IUsuarioRepositorio repositorio,
        TokenService tokenService,
        IConfiguration config)
    {
        _repositorio = repositorio;
        _tokenService = tokenService;
        _config = config;
    }

    public string Executar(LoginInput input)
    {
        var usuario = _repositorio.ObterPorEmail(input.Email);

        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        if (!usuario.ValidarSenha(input.Senha))
            throw new Exception("Senha inválida");

        return _tokenService.GerarToken(usuario, _config);
    }
}