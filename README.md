# Fundamentación matemática e implementación de ECDSA

## Descripción

Este documento aborda la implementación y fundamentos teóricos del algoritmo de firma digital ECDSA (Elliptic Curve Digital Signature Algorithm). A continuación, se presentan los puntos clave:

- **Definición de estructuras algebraicas:** Se explican conceptos como anillos, anillos unitarios, anillos de división y cuerpos, esenciales para entender las curvas elípticas.
- **Curvas elípticas:** Se define una curva elíptica y se detallan sus propiedades, incluyendo la ecuación de Weierstrass y el discriminante.
- **Operaciones en curvas elípticas:** Se describen las operaciones de suma y multiplicación de puntos en una curva elíptica, fundamentales para ECDSA.
- **Grupo de puntos de la curva:** Se demuestra que los puntos de una curva elíptica forman un grupo abeliano bajo la operación de suma.

## Visualización de .ipynb
https://nbviewer.org/github/DanielS1103/ECDSA/blob/main/Implementaci%C3%B3n_y_fundamentaci%C3%B3n_de_ECDSA.ipynb

## Implementación
# Firma Digital con Curvas Elípticas (ECC)

Este proyecto implementa la generación de claves, la firma digital y la verificación de firmas utilizando criptografía basada en curvas elípticas (ECC).

## Descripción

Este repositorio ofrece una exploración teórica y práctica del **ECDSA (Elliptic Curve Digital Signature Algorithm)**, un estándar criptográfico ampliamente utilizado en aplicaciones como Bitcoin y TLS. A través de un Jupyter Notebook interactivo, se abordan desde los fundamentos matemáticos de las curvas elípticas hasta una implementación funcional del algoritmo, incluyendo ejemplos en campos finitos y la curva Secp256k1. El contenido está diseñado para estudiantes, desarrolladores y entusiastas de la criptografía que buscan entender los detalles técnicos detrás de las firmas digitales.

## 🧩 Fundamentos Algebraicos

### Anillos y Campos: La Base Estructural
Un **anillo** es un conjunto equipado con dos operaciones que generalizan la aritmética de enteros. Su estructura requiere que la suma forme un grupo conmutativo y la multiplicación sea asociativa, distribuyéndose sobre la suma. Los **campos** extienden esta noción al garantizar que todo elemento no nulo tenga inverso multiplicativo, creando un sistema numérico completo para operaciones algebraicas.

La importancia de los campos primos \( \mathbb{Z}_p \) (donde \( p \) es primo) radica en su uso omnipresente en criptografía: permiten construir sistemas donde las operaciones modulares preservan propiedades algebraicas esenciales para la seguridad.

---

## 🌐 Curvas Elípticas: Geometría Algebraica Aplicada

### Construcción Matemática
Una curva elíptica sobre un campo finito se define mediante una ecuación cúbica especial que elimina singularidades. Esta elección garantiza que el conjunto de soluciones, junto con un "punto en el infinito", forme un grupo abeliano bajo una operación geométrica única.

### Operaciones de Grupo
- **Suma de puntos**: Se traza una recta entre dos puntos; el tercer punto de intersección con la curva se refleja sobre el eje x para obtener el resultado.
- **Doblado de puntos**: Para sumar un punto consigo mismo, se usa la tangente a la curva en ese punto como línea guía.

El **Teorema de Hasse** cuantifica la distribución de puntos en estas curvas, vinculando propiedades algebraicas con restricciones aritméticas fundamentales para aplicaciones criptográficas.

---

## 🔐 ECDSA: Mecánica Criptográfica

### Generación de Claves
1. **Clave privada**: Entero secreto seleccionado dentro de un rango determinado por el orden del grupo.
2. **Clave pública**: Punto en la curva derivado de multiplicar escalarmente la clave privada por un generador predefinido.

### Proceso de Firma Digital
1. **Hash criptográfico**: Transformación del mensaje a un resumen numérico único.
2. **Nonce efímero**: Valor secreto temporal que asegura la unicidad de cada firma.
3. **Geometría algebraica**: Cálculo de dos componentes (\( r \), \( s \)) usando operaciones de grupo y aritmética modular, vinculando irreversiblemente el mensaje a la clave privada.

### Verificación Matemática
Los verificadores reconstruyen una ecuación de grupo usando la clave pública, demostrando que solo el poseedor de la clave privada pudo generar la firma válida. Este proceso aprovecha propiedades de no repudio inherentes a las estructuras algebraicas subyacentes.

---

## ⚙️ Implementación Computacional

### Algoritmos Clave
- **Inverso modular**: Calculado mediante el algoritmo extendido de Euclides, esencial para resolver ecuaciones en aritmética modular.
- **Multiplicación escalar**: Optimizada usando el método de "doblado y suma" para manejar operaciones con números extremadamente grandes.

### Parámetros de Curva Estándar
La implementación utiliza **Secp256k1**, curva estandarizada empleada en Bitcoin. Sus parámetros incluyen:
- Campo primo de 256 bits
- Ecuación \( y^2 = x^3 + 7 \)
- Punto generador con coordenadas específicas
- Orden primo del grupo, asegurando que todos los elementos sean generadores potenciales

---

## 📊 Visualización Interactiva

El proyecto incluye herramientas para:
1. Graficar curvas elípticas sobre campos pequeños
2. Animaciones de operaciones de grupo
3. Demostraciones de firma/verificación en tiempo real

Estas visualizaciones desmitifican conceptos abstractos al mostrar cómo las operaciones algebraicas se traducen en movimientos geométricos concretos.

---

## 📚 Marco Teórico

### Seguridad Criptográfica
La fortaleza de ECDSA reside en la dificultad del **Problema del Logaritmo Discreto en Curvas Elípticas (ECDLP)**: Dados puntos \( P \) y \( Q = kP \), encontrar \( k \) es computacionalmente inviable para parámetros bien elegidos.

### Optimizaciones Matemáticas
- **Compresión de puntos**: Almacenar solo la coordenada x y un bit de paridad para y
- **Precomputación de tablas**: Acelera multiplicaciones escalares frecuentes
- **Firmas determinísticas**: Elimina dependencia de valores aleatorios mediante derivación determinista de nonces

---

## 🛠️ Uso del Proyecto

El repositorio contiene:
- Implementación completa de ECDSA
- Ejemplos con campos finitos pequeños para propósitos educativos
- Tests unitarios que validan propiedades algebraicas
- Notebooks interactivos con demostraciones paso a paso

---

### Ejemplos Prácticos 🛠️

#### Ejemplo en Campo Pequeño
- **Curva**: \( y^2 = x^3 + 7 \) sobre \( 𝔽_{61} \).
- **Visualización interactiva**: Gráficos de puntos de la curva y animación de operaciones.

#### Secp256k1 (Curva de Bitcoin)
- **Parámetros**:
  - `p = 2²⁵⁶ - 2³² - 977`.
  - **`n`**: Orden del grupo (número primo que define el tamaño del subgrupo generado por `G`).
  - Punto base `G` con coordenadas específicas.
- **Caso real**: Generación de claves, firma y verificación de mensajes.

---

## Requisitos 📋

- **Python 3.8+**.
- **Bibliotecas**:
  ```bash
  pip install matplotlib ipython
