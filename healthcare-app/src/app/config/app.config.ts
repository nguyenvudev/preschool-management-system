export const APP_CONFIG = {
    APP_NAME: 'Preschool Health Management',
    API_BASE_URL: import.meta.env.VITE_API_URL || 'http://localhost:5290/api',
    VERSION: import.meta.env.VITE_APP_VERSION || '1.0.0',
    MODE: import.meta.env.MODE || 'development',
  } as const;


  export const DATE_FORMATS = {
    DISPLAY: 'dd/MM/yyyy',
    DISPLAY_WITH_TIME: 'dd/MM/yyyy HH:mm',
    API: 'yyyy-MM-dd',
    API_WITH_TIME: "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'",
  } as const;
  
  // Environment variables with validation
  export const env = {
    VITE_API_URL: import.meta.env.VITE_API_URL || 'http://localhost:5290/api',
    VITE_APP_MODE: import.meta.env.MODE || 'development',
    VITE_APP_VERSION: import.meta.env.VITE_APP_VERSION || '1.0.0',
  } as const;