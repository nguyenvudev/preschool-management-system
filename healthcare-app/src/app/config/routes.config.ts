export const ROUTES = {
    // Public routes
    LOGIN: '/login',
    REGISTER: '/register',
    FORGOT_PASSWORD: '/forgot-password',
    
    // Protected routes
    DASHBOARD: '/dashboard',
    
    // Student Management
    STUDENTS: '/students',
    STUDENT_CREATE: '/students/create',
    STUDENT_EDIT: '/students/:id/edit',
    STUDENT_DETAIL: '/students/:id',
    
    // Class Management
    CLASSES: '/classes',
    CLASS_CREATE: '/classes/create',
    CLASS_EDIT: '/classes/:id/edit',
    CLASS_DETAIL: '/classes/:id',
    
    // User Management
    USERS: '/users',
    USER_CREATE: '/users/create',
    USER_EDIT: '/users/:id/edit',
    
    // Teacher Features
    ATTENDANCE: '/attendance',
    NUTRITION: '/nutrition',
    HEALTH_MONITORING: '/health',
    
    // Reports
    REPORTS: '/reports',
    FINANCE_REPORTS: '/reports/finance',
    HEALTH_REPORTS: '/reports/health',
    ATTENDANCE_REPORTS: '/reports/attendance',
    
    // Profile & Settings
    PROFILE: '/profile',
    SETTINGS: '/settings',
  } as const;
  
  // Helper function to generate routes with params
  export const buildRoute = (route: string, params: Record<string, string> = {}): string => {
    let result = route;
    Object.keys(params).forEach(key => {
      result = result.replace(`:${key}`, params[key]);
    });
    return result;
  };
  
  // Route groups for navigation
  export const ROUTE_GROUPS = {
    ADMIN: [
      ROUTES.DASHBOARD,
      ROUTES.STUDENTS,
      ROUTES.CLASSES,
      ROUTES.USERS,
      ROUTES.REPORTS,
    ],
    TEACHER: [
      ROUTES.DASHBOARD,
      ROUTES.STUDENTS,
      ROUTES.ATTENDANCE,
      ROUTES.NUTRITION,
      ROUTES.HEALTH_MONITORING,
    ],
    HEALTH_STAFF: [
      ROUTES.DASHBOARD,
      ROUTES.HEALTH_MONITORING,
      ROUTES.REPORTS,
    ],
  } as const;