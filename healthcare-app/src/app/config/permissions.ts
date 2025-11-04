export const ROLES = {
    ADMIN: 'admin',
    TEACHER: 'teacher', 
    PARENT: 'parent',
    HEALTH_STAFF: 'health_staff',
  } as const;
  
  export type UserRole = typeof ROLES[keyof typeof ROLES];
  
  // Định nghĩa type cho permissions trước
  export type Permission = 
    | 'users:read' | 'users:write' | 'users:delete'
    | 'students:read' | 'students:write' | 'students:delete' 
    | 'classes:read' | 'classes:write' | 'classes:delete'
    | 'finance:read' | 'finance:write'
    | 'reports:read' | 'reports:write'
    | 'attendance:read' | 'attendance:write'
    | 'nutrition:read' | 'nutrition:write'
    | 'health:read' | 'health:write'
    | 'system:admin';
  
  // Sau đó định nghĩa PERMISSIONS với type rõ ràng
  export const PERMISSIONS: Record<UserRole, readonly Permission[]> = {
    [ROLES.ADMIN]: [
      'users:read', 'users:write', 'users:delete',
      'students:read', 'students:write', 'students:delete',
      'classes:read', 'classes:write', 'classes:delete',
      'finance:read', 'finance:write',
      'reports:read', 'reports:write',
      'system:admin',
    ] as const,
    [ROLES.TEACHER]: [
      'students:read', 
      'classes:read',
      'attendance:read', 'attendance:write',
      'nutrition:read', 'nutrition:write',
      'health:read', 'health:write',
      'reports:read',
    ] as const,
    [ROLES.HEALTH_STAFF]: [
      'students:read',
      'health:read', 'health:write',
      'reports:read',
    ] as const,
    [ROLES.PARENT]: [
      'students:read',
      'attendance:read',
      'nutrition:read',
      'health:read',
    ] as const,
  } as const;
  
  // Helper functions
  export const hasPermission = (userRole: UserRole, permission: Permission): boolean => {
    return PERMISSIONS[userRole]?.includes(permission) ?? false;
  };
  
  export const hasAnyPermission = (userRole: UserRole, permissions: Permission[]): boolean => {
    return permissions.some(permission => hasPermission(userRole, permission));
  };
  
  export const hasAllPermissions = (userRole: UserRole, permissions: Permission[]): boolean => {
    return permissions.every(permission => hasPermission(userRole, permission));
  };