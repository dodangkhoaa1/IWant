using UnityEngine;

public static class AddressAPI
{
    public static readonly string PLAYER_URL = "http://localhost:5000/api/players";

    public static readonly string TEXT_TO_SPEECH_URL = "https://api.edenai.run/v2/audio/text_to_speech";
    public static readonly string TEXT_TO_SPEECH_API_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiMTY0NTQ0MjAtMmIzMC00MDgxLThjNGYtMTkwZjRmOGRjODgxIiwidHlwZSI6ImFwaV90b2tlbiJ9.0Pde4P6T4eRr0IMI-iyhezGKiSk1e-9XvJTIwRGFOow"; // API Key
    public static readonly string MALE_PROVIDER = "microsoft/vi-VN-NamMinhNeural";
    public static readonly string FEMALE_PROVIDER = "microsoft/vi-VN-HoaiMyNeural";
}
