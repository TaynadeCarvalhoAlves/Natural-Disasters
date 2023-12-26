using Dapper;
using MySqlConnector;
using Natural_Disasters_Web_Api.Domain.Entities;
using Natural_Disasters_Web_Api.Domain.Interfaces;


namespace Natural_Disasters_Web_Api.Domain.Repositorios
{
    public class UserRepository : IUserInterface
    {

        private readonly IConfiguration _configuration;
       
        private string _conexao { get { return _configuration.GetConnectionString("mysqldb"); } }

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        public async Task<IEnumerable<User>> CreateUser(User user)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                var dados = "insert into user (email, senha) values (@email, @senha)";
                await conexao.ExecuteAsync(dados, user);

                return await conexao.QueryAsync<User>("select * from user");
            }
        }

        public async Task<IEnumerable<User>> UpdateUser(User user)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                var dados = "update user set email = @email , senha = @senha where id = @id";
                await conexao.ExecuteAsync(dados, user);

                return await conexao.QueryAsync<User>("select * from user");
            }
        }

        public async Task<IEnumerable<User>> DeleteUser(int userId)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                var dados = "delete from user where id = @id";
                await conexao.ExecuteAsync(dados, new { Id = userId });

                return await conexao.QueryAsync<User>("select * from user");
            }
        }


        public async Task<IEnumerable<User>> GetAlluser()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                var dados = "select * from user";
                return await conexao.QueryAsync<User>(dados);
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                var dados = "select * from user where id = @Id";

                return await conexao.QueryFirstOrDefaultAsync<User>(dados, new {Id = userId});
            }
        }


    }
}
