namespace EmDijes1.Utils
{
    public static class EmocionHelper
    {
        public static string MapearEmocion(string emocion)
        {
            return emocion?.ToLowerInvariant() switch
            {
                "happy" or "feliz" => "feliz",
                "sad" or "triste" => "triste",
                "angry" or "enojado" => "enojado",
                "surprised" or "sorprendido" => "sorprendido",
                "disgusted" or "disgustado" => "disgustado",
                _ => "neutral"
            };
        }

        public static string[] ObtenerPreguntasSegunEmocion(string emocion)
        {
            var e = MapearEmocion(emocion);
            return e switch
            {
                "feliz" => new[]
                {
                    "¿Por qué te sientes feliz hoy?",
                    "¿Qué situación o persona ha influido más en tu felicidad?",
                    "¿Has agradecido a Dios por este momento de alegría?",
                    "¿Cómo describirías tu paz interior en este momento?",
                    "¿Con quién te gustaría compartir tu felicidad?",
                    "¿Qué te ayuda a mantenerte positivo y animado?",
                    "¿Sientes que tu relación con Dios fortalece tu alegría? ¿Por qué?"
                },
                "triste" => new[]
                {
                    "¿Qué te ha hecho sentir triste hoy?",
                    "¿Hay alguien con quien puedas hablar sobre cómo te sientes?",
                    "¿Qué te ayudaría a sentirte un poco mejor en este momento?",
                    "¿Sientes que tienes paz interior a pesar de la tristeza?",
                    "¿Has buscado apoyo en Dios o en personas cercanas?",
                    "¿Qué cosas te han ayudado antes a superar momentos difíciles?",
                    "¿Sientes que tu relación con Dios te da consuelo en la tristeza?"
                },
                "enojado" => new[]
                {
                    "¿Qué situación te ha provocado enojo?",
                    "¿Cómo sueles manejar el enojo en tu vida diaria?",
                    "¿Hay alguien con quien puedas hablar para desahogarte?",
                    "¿Qué te ayudaría a encontrar paz en este momento?",
                    "¿Has intentado buscar calma o apoyo en Dios?",
                    "¿Qué actividades te ayudan a liberar el enojo de forma saludable?",
                    "¿Sientes que tu relación con Dios te ayuda a controlar el enojo?"
                },
                "sorprendido" => new[]
                {
                    "¿Qué te ha sorprendido recientemente?",
                    "¿Cómo te sentiste al recibir esa sorpresa?",
                    "¿Crees que esta sorpresa ha cambiado tu estado de ánimo?",
                    "¿Has compartido esta experiencia con alguien cercano?",
                    "¿Sientes que Dios tiene un propósito en lo inesperado?",
                    "¿Qué te ayuda a adaptarte a los cambios inesperados?",
                    "¿Cómo influye tu relación con Dios cuando enfrentas sorpresas?"
                },
                "disgustado" => new[]
                {
                    "¿Por qué te sientes disgustado hoy?",
                    "¿Qué situación o persona ha generado este disgusto?",
                    "¿Cómo te afecta emocionalmente este disgusto?",
                    "¿Qué te ayudaría a sentirte mejor ahora?",
                    "¿Has buscado apoyo en Dios o en alguien de confianza?",
                    "¿Qué estrategias usas para recuperar la paz interior?",
                    "¿Sientes que tu relación con Dios te ayuda a superar el disgusto?"
                },
                _ => new[]
                {
                    "¿Cómo te sientes hoy y qué palabra describe mejor tu estado de ánimo?",
                    "¿Qué situación o persona ha influido más en cómo te sientes ahora?",
                    "¿Sientes que tienes paz interior en este momento? ¿Por qué?",
                    "¿Hay algo que te gustaría cambiar o mejorar en tu vida emocional o espiritual?",
                    "¿A quién puedes acudir cuando necesitas apoyo o ánimo?",
                    "¿Qué cosas te ayudan a sentirte mejor cuando enfrentas momentos difíciles?",
                    "¿Sientes que tu relación con Dios te da fortaleza o consuelo? ¿Por qué?"
                }
            };
        }
    }
}