using UnityEngine;

public static class AddressAPI
{
    public static readonly string BASE_URL = "http://localhost:5000";
    public static readonly string USER_URL = BASE_URL + "/api/users";
    public static readonly string WORD_URL = BASE_URL + "/api/words";

    public static readonly string TEXT_TO_SPEECH_URL = "https://api.edenai.run/v2/audio/text_to_speech";
    public static readonly string TEXT_TO_SPEECH_API_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiMTY0NTQ0MjAtMmIzMC00MDgxLThjNGYtMTkwZjRmOGRjODgxIiwidHlwZSI6ImFwaV90b2tlbiJ9.0Pde4P6T4eRr0IMI-iyhezGKiSk1e-9XvJTIwRGFOow"; // API Key
    public static readonly string MALE_VI_VN = "microsoft/vi-VN-NamMinhNeural";
    public static readonly string FEMALE_VI_VN = "microsoft/vi-VN-HoaiMyNeural";
    
    public static readonly string MALE_EN_US = "microsoft/en-US-JasonNeural";
    public static readonly string FEMALE_EN_US = "microsoft/en-US-SaraNeural";
}
