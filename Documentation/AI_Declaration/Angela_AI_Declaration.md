Declaración de IA
 Herramienta y versión utilizada: Claude  by Anthropic
 Propósito:  Me ayudo a organizar los scripts en C# (UIManager.cs y controladores de audio), solucione algunas dudas respecto al inspector y por ultimo me guio en el trabajo sonoro del videojuego
 Prompts literales utilizados en inglés:
1.	“In my Unity UIManager script, add a ShowSubtitle(string message, float duration) method that uses a coroutine to display the text and hide it after the duration. Also add a TriggerVisualFeedback() method that makes a UI Image panel flash briefly and fade out slowly (no more than one flash per second, to comply with WCAG 2.3.1). Keep my existing methods and add English comments.”
2.	"How can I write a C# script for a UIManager in Unity to update UI text elements like CalmLightsText and SubtitleText dynamically, and trigger a FlashPanel fade effect when events occur?"
3.	"I need to check why my UIManager script in Unity is not updating the TextMeshPro elements correctly during gameplay. What public methods should I use and how do I link them properly?"
4.	"How can I link a UI Slider component in Unity to control the background music volume dynamically using an AudioSource?"
5.	"What is the best way to structure a SceneAudioController script in Unity to manage background music and multiple sound effects like jumps, checkpoints, and collections from the Inspector?"
6.	"I have a problem where my audio controller or AudioManager is not playing sound effects properly when triggered, what could be causing this error in C#?"
 Marcado de código y modificaciones manuales:
Los códigos con el propósito de efectos de desvanecimiento se hicieron con ayuda de Claude, por eso se encontrarán comentarios que indican cuales son las partes con IA.



