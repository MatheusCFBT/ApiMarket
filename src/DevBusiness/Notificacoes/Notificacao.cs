using DevBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBusiness.Notificacoes
{
    public class Notificacao
    {
        public readonly string Mensagem;

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }

    public class Notificador : INotificador
    {
        private List<Notificacao> _notifacacoes;

        public Notificador()
        {
            _notifacacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notifacacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notifacacoes;
        }

        public bool TemNotificacao()
        {
            return _notifacacoes.Any();
        }
    }
}
