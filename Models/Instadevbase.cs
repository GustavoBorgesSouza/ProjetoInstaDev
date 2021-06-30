using System.Collections.Generic;
using System.IO;

namespace ProjetoInstaDev.Models
{
    public abstract class Instadevbase
    {
        public void CriarPastaEArquivo(string _caminho)
        {

            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> LerTodasLinhasCSV(string _caminho)
        {

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(_caminho)) //using: usa o arquivo e fecha junto com o using  || StreamReader: lê tudo
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public void ReescreverCSV(string _caminho, List<string> linhas)
        {

            using (StreamWriter output = new StreamWriter(_caminho)) // StreamWriter: Escreve o arquivo todo
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }


    }
}