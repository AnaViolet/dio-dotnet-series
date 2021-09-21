using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public Serie RetornarPorId(int id)
        {
            return listaSerie[id];
        }

        public void Inserir(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public void Excluir(int id)
        {
            //listaSerie.RemoveAt[id];
            listaSerie[id].excluir();
        }

        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }
    }
}