export const API_ENDPOINTS = {
    // Auth endpoints
    AUTH: {
      LOGIN: '/Auth/login',
      REGISTER: '/Auth/register',
      REFRESH_TOKEN: '/Auth/refresh-token',
      LOGOUT: '/Auth/logout',
      PROFILE: '/Auth/profile',
      CHANGE_PASSWORD: '/Auth/change-password',
    },
    
    // Student endpoints
    STUDENTS: {
      BASE: '/Students',
      BY_ID: (id: string) => `/Students/${id}`,
      BY_CODE: (code: string) => `/Students/code/${code}`,
      HEALTH_RECORDS: (id: string) => `/Students/${id}/health-records`,
      BIRTHDAYS: '/Students/birthdays',
    },
    
    // User endpoints
    USERS: {
      BASE: '/Users',
      BY_ID: (id: string) => `/Users/${id}`,
      TOGGLE_ACTIVE: (id: string) => `/Users/${id}/toggle-active`,
    },
    
    // Class endpoints
    CLASSES: {
      BASE: '/Classes',
      BY_ID: (id: string) => `/Classes/${id}`,
      STUDENTS: (id: string) => `/Classes/${id}/students`,
      ASSIGN_TEACHER: (id: string) => `/Classes/${id}/assign-teacher`,
      SCHEDULE: (id: string) => `/Classes/${id}/schedule`,
    },
    
    // Attendance endpoints
    ATTENDANCE: {
      BASE: '/Attendance',
      BY_CLASS: (classId: string) => `/Attendance/class/${classId}`,
      BY_STUDENT: (studentId: string) => `/Attendance/student/${studentId}`,
      BULK: '/Attendance/bulk',
    },
    
    // Nutrition endpoints
    NUTRITION: {
      BASE: '/Nutrition',
      MENU: '/Nutrition/menu',
      MEAL_PLAN: '/Nutrition/meal-plan',
      CHATBOT: '/Nutrition/chatbot',
    },
    
    // Health endpoints
    HEALTH: {
      BASE: '/Health',
      RECORDS: '/Health/records',
      CHECKUPS: '/Health/checkups',
      VACCINES: '/Health/vaccines',
    },
    
    // Finance endpoints
    FINANCE: {
      BASE: '/Finance',
      FEES: '/Finance/fees',
      PAYMENTS: '/Finance/payments',
      INVOICES: '/Finance/invoices',
    },
    
    // Notification endpoints
    NOTIFICATIONS: {
      BASE: '/Notifications',
      SEND: '/Notifications/send',
      BULK: '/Notifications/bulk',
    },
    
    // Reports endpoints
    REPORTS: {
      BASE: '/Reports',
      STUDENTS: '/Reports/students',
      ATTENDANCE: '/Reports/attendance',
      FINANCE: '/Reports/finance',
      HEALTH: '/Reports/health',
    },
  } as const;