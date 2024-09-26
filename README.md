# Fundamentación matemática e implementación de ECDSA

## Descripción

Este documento aborda la implementación y fundamentos teóricos del algoritmo de firma digital ECDSA (Elliptic Curve Digital Signature Algorithm). A continuación, se presentan los puntos clave:

- **Definición de estructuras algebraicas:** Se explican conceptos como anillos, anillos unitarios, anillos de división y cuerpos, esenciales para entender las curvas elípticas.
- **Curvas elípticas:** Se define una curva elíptica y se detallan sus propiedades, incluyendo la ecuación de Weierstrass y el discriminante.
- **Operaciones en curvas elípticas:** Se describen las operaciones de suma y multiplicación de puntos en una curva elíptica, fundamentales para ECDSA.
- **Grupo de puntos de la curva:** Se demuestra que los puntos de una curva elíptica forman un grupo abeliano bajo la operación de suma.

## Implementación
# Firma Digital con Curvas Elípticas (ECC)

Este proyecto implementa la generación de claves, la firma digital y la verificación de firmas utilizando criptografía basada en curvas elípticas (ECC).

## Descripción

El uso de ECC permite generar claves más pequeñas con el mismo nivel de seguridad que otros algoritmos como RSA. En esta parte se detalla el proceso de generación de claves, firma y verificación de firmas digitales.

## Generación de Claves

1. **Selección de Curva y Punto Base:**
   - Se elige una curva elíptica adecuada y un punto base G en la curva.
   
2. **Clave Privada:**
   - Se selecciona un número entero aleatorio d como clave privada.
   
3. **Clave Pública:**
   - Se calcula Q = d * G, donde Q es un punto en la curva.

## Firma Digital

1. **Hash del Mensaje:**
   - Se crea un hash del mensaje utilizando una función hash criptográfica, como SHA256.
   
2. **Cálculo de R:**
   - Se selecciona un entero aleatorio k y se calcula R = k * G.
   
3. **Cálculo de s:**
   - Se calcula s = k^(-1) * (m + r * d) mod n, donde:
     - m es el hash del mensaje.
     - r es la coordenada x del punto R.
     - n es el orden del punto base G.

## Verificación de la Firma

1. **Hash del Mensaje:**
   - Se calcula el hash del mensaje recibido.
   
2. **Cálculo de u1 y u2:**
   - Se calculan los valores:
     - u1 = m * s^(-1) mod n
     - u2 = r * s^(-1) mod n
   
3. **Verificación del Punto:**
   - Se verifica que R = u1 * G + u2 * Q.

## Dependencias

- Python 3.x
- Bibliotecas para criptografía: `ecdsa`, `hashlib`

## Ejecución

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tu_usuario/tu_repositorio.git
