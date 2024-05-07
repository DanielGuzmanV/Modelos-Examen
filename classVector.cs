﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newVectores2
{
    class classVector
    {
        // Atributos 
        const int dimension = 50;
        private int[] vector;
        private int cantidad;

        // Constructor 
        public classVector()
        {
            vector = new int[dimension];
            cantidad = 0;
        }

        // Metodos y funciones auxiliares para los ejercicios ***********
        
        // Metodos para cargar, descargar y cargar elemento por elemento

        // Cargar elementos random ----------------------------
        public void cargarRandom(int cant, int ini, int fin)
        {
            Random rand = new Random();
            this.cantidad = cant;
            for(int ter = 1; ter <= this.cantidad; ter++)
            {
                vector[ter] = rand.Next(ini, fin + 1);
            }
        }

        // Descargar elementos random --------------------------
        public string descargar()
        {
            string separador = "";
            for(int ter = 1; ter <= this.cantidad; ter++)
            {
                separador = separador + vector[ter] + "|";
            }
            return separador;
        }

        // Cargar elemento por elemento ----------------------
        public void cargarElexEle(int number)
        {
            this.cantidad = this.cantidad + 1; // o this.cantidad++; "Manera mas simple"
            vector[this.cantidad] = number;
        }

        // *** Funciones auxiliares ***
        // ----------------------------

        // Funcion para intercambio de elementos -------------
        public void intercambio(int date1, int date2)
        {
            int auxi = vector[date2];
            vector[date2] = vector[date1];
            vector[date1] = auxi;
        }
        
        // Funcion ordenamiento por parametros ---------------
        public void ordenParametros(int ini, int fin)
        {
            for(int ter1 = ini; ter1 < fin; ter1++)
            {
                for(int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                {
                    // Hacemos el cambio aqui para ordenar de mayor a menor o de menor a mayor (solo por parametros)
                    if(vector[ter2] < vector[ter1])
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }

        // Funcion para busqueda secuencial de un elemento
        public bool busquedaSecuencial(int number)
        {
            bool respu = false; int ter = 1;
            while (ter <= this.cantidad && respu == false)
            {
                if(vector[ter] == number)
                {
                    respu = true;
                }
                ter++;
            }
            return respu;
        }

        // Funcion para frecuencia de un elemento
        public int frecuenciaElem(int number)
        {
            int conta = 0;
            for(int ter = 1; ter <= this.cantidad; ter++)
            {
                if(vector[ter] == number)
                {
                    conta++;
                }
            }
            return conta;
        }

        // Funcion auxiliar para ordenar sin parametros
        public void ordenSinparametros()
        {
            for(int ter1 = 1; ter1 < this.cantidad; ter1++)
            {
                for (int ter2 = ter1 + 1; ter2 <= this.cantidad; ter2++)
                {
                    if(vector[ter2] < vector[ter1])
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }

        // Funcion auxiliar para encontrar un elemento mayor del vector por parametros
        public int elemMaximo(int number, int ini, int fin)
        {
            for(int posi = ini; posi <= fin; posi++)
            {
                if(vector[posi] == number)
                {
                    number = vector[posi];
                }
            }
            return number;
        }

        // Modelos de examen *********************************

        // Pregunta 1: Encontrar elemento y frecuencia (ordenado de < a >)
        // de elementos de fibonacci del rango a y b

        public void elemFrecuFibonacci(int ini, int fin, ref classVector vecEle, ref classVector vecFrecu)
        {
            vecEle.cantidad = 0;
            vecFrecu.cantidad = 0;

            int ter1, ele, frecu, varfibo, varA, varB;
            ter1 = ini; varfibo = 0; varA = 0; varB = 1;

            this.ordenParametros(ter1, fin);
            while(ter1 <= fin)
            {
                varfibo = varA + varB;
                frecu = 0;
                ele = vector[ter1];
                
                if(ele == varfibo)
                {
                    while(ter1 <= fin && vector[ter1] == ele)
                    {
                        ter1++; frecu++;
                    }
                    vecEle.cargarElexEle(ele);
                    vecFrecu.cargarElexEle(frecu);
                    varA = varB; varB = varfibo;
                }
                else if(ele < varfibo)
                {
                    ter1++;
                }
                else if(ele > varfibo)
                {
                    varA = varB; varB = varfibo;
                }
            }
        }
        // Pregunta 2: Cargar randomicamente el vector sin repetidos
        public void cargarSinRepet(int cant, int ini, int fin)
        {
            Random rand = new Random();
            int ele;
            do
            {
                ele = rand.Next(ini, fin + 1);
                if (!(busquedaSecuencial(ele)))
                {
                    this.cantidad++;
                    vector[this.cantidad] = ele;
                }
            } while (!(this.cantidad == cant));
        }
        
        // Pregunta 3: Eliminar los elementos de posicion multiplos, donde solo
        // estaran los elementos que no seran multiplos

        public void elimPosMultiplos(int number)
        {
            int conta, resi;
            conta = 0;
            for(int ter = 1; ter <= this.cantidad; ter++)
            {
                resi = ter % number;
                if(resi != 0)
                {
                    conta++;
                    vector[conta] = vector[ter];
                }
            }
            this.cantidad = conta;
        }

        // Pregunta 4: Segmentar el vector en repetidos y no repetidos
        // ordenados descendentemente

        public void segmentarRepetYNoRepet()
        {
            for(int ter1 = 1; ter1 < this.cantidad; ter1++)
            {
                for(int ter2 = ter1 + 1; ter2 <= this.cantidad; ter2++)
                {
                    if((frecuenciaElem(vector[ter2]) != 1) && (!(frecuenciaElem(vector[ter1]) != 1)) ||
                        (frecuenciaElem(vector[ter2]) != 1) && (frecuenciaElem(vector[ter1]) != 1) && (vector[ter2] > vector[ter1]) ||
                        (!(frecuenciaElem(vector[ter2]) != 1)) && (!(frecuenciaElem(vector[ter1]) !=1 )) && (vector[ter2] > vector[ter1]))
                    {
                        this.intercambio(ter2, ter1);
                    }
                }
            }
        }
        
        // Pregunta 5: Encontrar elemento y frecuencia del rango a y b, donde los elementos
        // estan ordenados descendentemente (mayor a menor) y el resultado es de aquellos que tienen frecuencia
        public void elementFrecu(int ini, int fin, ref classVector vecEle, ref classVector vecFrecu)
        {
            vecEle.cantidad = 0;
            vecFrecu.cantidad = 0;

            int ele, frecu, ter;
            ter = ini;
            this.ordenParametros(ter, fin);
            while(ter <= fin)
            {
                frecu = 0;
                ele = vector[ter];
                while(ter <= fin && vector[ter] == ele)
                {
                    ter++; frecu++;
                }
                if(frecu != 1)
                {
                    vecEle.cargarElexEle(ele);
                    vecFrecu.cargarElexEle(frecu);
                    // Para ordenar de mayor a menor cambiamos la funcion auxiliar
                    // ordenParametros(), osea de "<" a ">"
                }
            }
        }
        
        // Pregunta 6: Ordenar de mayor a menor los elementos de posiciones 
        // multiplos de m
        public void ordenMayMenPosMulti(int number)
        {
            int media = this.cantidad / number;
            for(int ter1 = 1; ter1 < media; ter1++)
            {
                for(int ter2 = ter1 + 1; ter2 <= media; ter2++)
                {
                    if(vector[ter2 * number] > vector[ter1 * number])
                    {
                        this.intercambio((ter2 * number), (ter1 * number));
                    }
                }
            }
        }

        // Pregunta 7: eliminar elementos repetidos "Purgar" del vector, debe quedar
        // solo elemento. *LA PURGAR DEBE SER EN EL MISMO VECTOR*
        public void elimElemRepet()
        {
            int ele, ter1, cont;
            ter1 = 1; cont = 0;
            this.ordenSinparametros();

            while(ter1 <= this.cantidad)
            {
                ele = vector[ter1];
                while(ter1 <= this.cantidad && vector[ter1] == ele)
                {
                    ter1++;
                }
                cont++;
                vector[cont] = ele;
            }
            this.cantidad = cont;
        }

        // Pregunta 8: Cargar Randomicamente 2 vectores "conjuntos" 
        // SIN ELEMENTOS REPETIDOS y realizar la union
        public void unioVectoresSinRepet(classVector vect2, ref classVector vectResult)
        {
            for(int ter1 = 1; ter1 <= this.cantidad; ter1++)
            {
                vectResult.cargarElexEle(vector[ter1]);
            }
            for(int ter2 = 1; ter2 <= vect2.cantidad; ter2++)
            {
                if (!(busquedaSecuencial(vect2.vector[ter2])))
                {
                    vectResult.cargarElexEle(vect2.vector[ter2]);
                }
            }
        }

        // Pregunta 9: Intecalar mayor y menor del rango a y b
        // Ejemplo v[4,7|8,6,4,9,3,5,9,3|4,6]
        //               a             b
        //         v[4,7|9,3,9,3,8,4,6,5|4,6]
        //               + - + - + - + -
        public void interMayMen(int ini, int fin)
        {
            bool cambio = true;
            for(int ter1 = ini; ter1 < fin; ter1++)
            {
                if(cambio == true)
                {
                    for(int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                    {
                        if((elemMaximo(vector[ter2], ini, fin) > 0) && (!(elemMaximo(vector[ter1], ini, fin) > 0)) ||
                            (elemMaximo(vector[ter2], ini, fin) > 0) && (elemMaximo(vector[ter1], ini, fin) > 0) && (vector[ter2] > vector[ter1])||
                            (!(elemMaximo(vector[ter2], ini, fin) > 0)) && (!(elemMaximo(vector[ter1], ini, fin) > 0)) && (vector[ter2] < vector[ter1]))
                        {
                            this.intercambio(ter2, ter1);
                        }
                    }
                }
                else
                {
                    for (int ter2 = ter1 + 1; ter2 <= fin; ter2++)
                    {
                        if ((!(elemMaximo(vector[ter1], ini, fin) > 0)) && (elemMaximo(vector[ter2], ini, fin) > 0) ||
                            (!(elemMaximo(vector[ter2], ini, fin) > 0)) && (!(elemMaximo(vector[ter1], ini, fin) > 0)) && (vector[ter2] > vector[ter1]) ||
                            (elemMaximo(vector[ter2], ini, fin) > 0) && (elemMaximo(vector[ter1], ini, fin) > 0) && (vector[ter2] < vector[ter1]))
                        {
                            this.intercambio(ter2, ter1);
                        }
                    }
                }
                cambio = !cambio;
            }
        }
    }
}
