import React, { useState } from 'react';

function FormularioIMC() {
  const [nombre, setNombre] = useState('');
  const [genero, setGenero] = useState('masculino');
  const [peso, setPeso] = useState('');
  const [altura, setAltura] = useState('');
  const [resultado, setResultado] = useState('');

  const calcularIMC = (peso, altura) => {
    const alturaEnMetros = altura / 100;
    return peso / (alturaEnMetros * alturaEnMetros);
  };

  const clasificarIMC = (imc) => {
    if (imc < 18.5) return "Bajo peso";
    else if (imc >= 18.5 && imc <= 24.9) return "Peso normal";
    else if (imc >= 25.0 && imc <= 29.9) return "Sobrepeso";
    else if (imc >= 30.0 && imc <= 34.9) return "Obesidad grado I";
    else if (imc >= 35.0 && imc <= 39.9) return "Obesidad grado II";
    else return "Obesidad grado III"; // IMC de 40.0 o más
  };

  const handleSubmit = (e) => {
    e.preventDefault();
  
    const imc = calcularIMC(peso, altura).toFixed(2);
    const clasificacion = clasificarIMC(imc);
    
    setResultado(`${nombre}, tu IMC es ${imc}, lo que indica una clasificación de: ${clasificacion}`);
    
    // Llama aquí a enviarDatosAPI para enviar los datos al servidor
    enviarDatosAPI();
  };
  

  const enviarDatosAPI = async () => {
    const url = await 'https://localhost:7044/api/IMC'; 
    const datos = {
      nombre,
      genero,
      peso,
      altura,
      resultado
    };
  
    try {
      const respuesta = await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(datos),
      });
  
      if (!respuesta.ok) {
        throw new Error('Algo salió mal al enviar los datos');
      }
  
      const respuestaJson = await respuesta.json();
      console.log('Respuesta de la API:', respuestaJson);
    } catch (error) {
      console.error('Error al enviar los datos:', error);
      
    }
  };
  
 
  

  return (
    <div className="container mx-10 bg-white shadow-lg overflow-hidden">
      <h2 className='text-gray-800 font-bold text-2xl uppercase text-center'>Calculadora de IMC</h2>
      <form onSubmit={handleSubmit} className="w-full mx-auto px-4 py-2">
        <div className="flex items-center py-2 space-y-1 border-b-2">
          <label htmlFor="nombre">Nombre:</label>
          <input
            className="appearance-none bg-transparent border-none w-full text-gray-700 py-2 px-3 leading-tight focus:outline-none"
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
                  text-white py-1 px-2 rounded">Calcular IMC</button>
      </form>
      {resultado && <div id="resultado">{resultado}</div>}
    </div>
  );
}

export default FormularioIMC;
