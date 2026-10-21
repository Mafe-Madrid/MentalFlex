Rol: UI/UX, Audio y Accesibilidad

Integrante responsable: Angela Gabriela Becerra Ortiz

Trabajo desarrollado en Unity 
En la etapa 3 del videojuego de MentalFlex trabajé en la parte de la interfaz, el audio y la accesibilidad la cuales fueron realizadas en el motor de Unity, en estos procedimientos se desarrollaron varios elementos dentro del Canvas, debido a que cada una cumple con una funcion diferente

Contador de luces de calma (CalmLightsText):  Se usa para mostrar cuantas luces ha recogido el jugar en el juego 

Subtítulos (SubtitleText): Es usado para mostrar los textos en pantalla y de esta manera el jugador no dependerá solamente de las indicaciones del audio 

Panel de destello (FlashPanel): Es un elemento visual que sirve para mostrar una respuesta cuando sucede algo importante en el juego, por ejemplo, recoger un objeto 

Control de volumen (MusicSlider): Permite que el jugador manipule el volumen del juego según sus preferencias 

Aplicación de los criterios de accesibilidad (WCAG 2.2 y DUA)

Además, se agregaron criterios de accesibilidad en la interfaz, para que diferentes usuarios puedan entender el juego de una manera fácil de utilizar 

 WCAG 2.2 - Criterio 1.2.2: Subtítulos
 
Implementación: Se agregó el elemento SubtitleText para mostrar mensajes en la pantalla.

Impacto: Esto mejora la comodidad de los usuarios, ya que al tener un buen tamaño y contraste, los textos se pueden leer con mayor facilidad y distinguir mejor del fondo del juego.

 WCAG 2.2 - Criterio 1.4.3: Contraste mínimo
Implementación: Se utilizó TextMeshPro para los tamaños y legibilidad de los textos, y además el color dependiendo del contraste del juego
Impacto: Al tener un buen tamaño y color para que contraste con el fondo, los textos son más fáciles de leer para las personas.

WCAG 2.2 - Criterio 1.4.2: Control de audio
Implementación: Se agregó el control MusicSlider para que el jugador pueda ajustar el volumen de la música.
Impacto: Esto permite que cada jugador ajuste el volumen como quiera, ya sea bajarlo o quitar la música, para que se sienta más cómodo mientras juega.

 DUA - Múltiples formas de representación
Implementación: Se usaron sonidos y elementos visuales en el juego, como el FlashPanel y el contador CalmLightsText, que  muestra cuántas luces de calma ha recogido el jugador

Impacto: Esto ayuda al jugador a saber cuánto ha avanzado mediante la información que aparece en pantalla y los sonidos del juego

3. Edición de audio
Para la parte del audio, edité el sonido del salto llamado jump 1 en Audacity. Utilicé la opción de normalizar para ajustar el volumen, ya que antes la música de fondo tapaba un poco el sonido del salto. Con este cambio, el sonido se escucha mejor y se puede distinguir más durante el juego.

