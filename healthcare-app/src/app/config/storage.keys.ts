// src/config/storage.keys.ts

/**
 * Keys used for localStorage / sessionStorage
 * to persist authentication, user preferences, and filters.
 */
export const STORAGE_KEYS = {
    // Authentication
    AUTH_TOKEN: 'authToken',
    REFRESH_TOKEN: 'refreshToken',
    USER: 'user',
  
    // Theme & UI Preferences
    THEME: 'theme',
    LANGUAGE: 'language',
  
    // Feature-specific keys
    STUDENT_FILTERS: 'student-filters',
    CLASS_FILTERS: 'class-filters',
    ATTENDANCE_FILTERS: 'attendance-filters',
    TABLE_PREFERENCES: 'table-preferences',
  
    // Other persisted data
    DASHBOARD_WIDGETS: 'dashboard-widgets',
  } as const;
  
  export type StorageKey = typeof STORAGE_KEYS[keyof typeof STORAGE_KEYS];
  