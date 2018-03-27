﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_1_Analise_Lexica.Lexer
{
    public class Token
    {
        private String lexema;
        private Tag classe;
        private int linha;
        private int coluna;

        public Token(Tag classe, String lexema, int linha, int coluna)
        {
            this.Classe = classe;
            this.Lexema = lexema;
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public string Lexema
        {
            get
            {
                return lexema;
            }

            set
            {
                lexema = value;
            }
        }

        public Tag Classe
        {
            get
            {
                return classe;
            }

            set
            {
                classe = value;
            }
        }

        public int Linha
        {
            get
            {
                return linha;
            }

            set
            {
                linha = value;
            }
        }

        public int Coluna
        {
            get
            {
                return coluna;
            }

            set
            {
                coluna = value;
            }
        }

        public String toString()
        {
            lexema = lexema.Replace("\r","\\r").Replace("\n","\\n");
            return "<" + classe + ", \"" + lexema + "\">";
        }

    }
}