import Header from './components/Header'
import React, { useState } from 'react';

function CalculadoraIMC() {
  // Estados para manejar los inputs del formulario
  const [nombre, setNombre] = useState('');
  const [genero, setGenero] = useState('masculino'); // Valor inicial como 'masculino'
  const [peso, setPeso] = useState('');
  const [altura, setAltura] = useState('');
  const [resultado, setResultado] = useState('');

  // Función para calcular el IMC
  const calcularIMC = (peso, altura) => {
    // Altura en metros y calculo del IMC
    const alturaEnMetros = altura / 100;
    return peso / (alturaEnMetros * alturaEnMetros);
  };

  const handleSubmit = (e) => {
    e.preventDefault(); // Previene el comportamiento por defecto del formulario

    // Calcula el IMC
    const imc = calcularIMC(peso, altura).toFixed(2); // Redondea a dos decimales

    // Actualiza el resultado
    setResultado(`${nombre}, tu IMC es ${imc}`);
  };

  return (
    <div className="container mx-10 bg-white shadow-lg overflow-hidden">
      <Header/>
      <h2 className='text-gray-800 font-bold text-2xl uppercase text-center'>Calculadora de IMC</h2>
      <form onSubmit={handleSubmit} className="w-full mx-auto px-4 py-2">
        <div className="flex items-center py-2 space-y-1 border-b-2">
          <label  htmlFor="nombre">Nombre:</label>
          <input
            className="appearance-none bg-transparent border-none w-full text-gray-700 py-2 px-3 
            leading-tight focus:outline-none"
            type="text"
            id="nombre"
            name="nombre"
            required
            value={nombre}
            onChange={(e) => setNombre(e.target.value)}
          />
        </div>
        <div className='py-2 space-y-1 border-b-2'>
          <label htmlFor="genero">Género:</label>
          <select
          className='m-2'
            id="genero"
            name="genero"
            required
            value={genero}
            onChange={(e) => setGenero(e.target.value)}
          >
            <option value="masculino">Masculino</option>
            <option value="femenino">Femenino</option>
          </select>
        </div>
        <div className='py-2 space-y-1 border-b-2'>
          <label htmlFor="peso">Peso (kg):</label>
          <input
            className='m-3'
            type="number"
            id="peso"
            name="peso"
            required
            value={peso}
            onChange={(e) => setPeso(e.target.value)}
          />
        </div>
        <div className='py-2 space-y-1 border-b-2'>
          <label htmlFor="altura">Altura (cm):</label>
          <input
            className='m-3'
            type="number"
            id="altura"
            name="altura"
            required
            value={altura}
            onChange={(e) => setAltura(e.target.value)}
          />
        </div>
        <button type="submit" className="flex-shrink-0 m-3
                  bg-teal-500 hover:bg-teal-800 
                  border-teal-500 
                  hover:border-teal-700 text-sm border-4 
                  text-white py-1 px-2 rounded ">Calcular IMC</button>
      </form>
      {resultado && <div id="resultado">{resultado}</div>}
    </div>
  );
}

export default CalculadoraIMC;
