using ClassificadosWeb.Domain.Entities;
using Xunit;

namespace ClassificadosWeb.Tests.Entities
{
    public class UserEntityTests
    {
        private readonly UserEntity validUser = new UserEntity("Nome valido", "Cidade valida", "SP", "11 3212-9874", "11 99999-9999", "email@email.com", "123456", "url da photo");

        [Fact]
        public void Dado_um_novo_usuario_nao_pode_estar_confirmado()
        {
            Assert.False(validUser.Confirmed);
        }

        [Fact]
        public void Quando_o_metodo_set_password_for_chamado_deve_alterar_a_senha()
        {
            string pass = "123";
            validUser.SetPassword(pass);

            Assert.Equal(pass, validUser.Password);
        }

        [Fact]
        public void Verificar_se_hash_da_senha_esta_funcionando_corretamente()
        {
            string pass = "123456";
            validUser.SetPassword(pass);
            validUser.HashPassword();

            bool passCorrect = validUser.ComparePasswordHash(pass);

            Assert.True(passCorrect);
        }
        
    }
}