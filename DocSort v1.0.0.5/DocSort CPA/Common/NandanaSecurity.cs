using System;
using System.Collections;
using Common;


namespace Security
{
    /// <summary>
    /// The Module Security Class
    /// </summary>
    public class NandanaSecurity
    {
        /// <summary>
        /// Default Constructor of Security Class
        /// </summary>
        public NandanaSecurity()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static ModuleSecurity CreateModuleSecurity(SiteModule module)
        {
            return new ModuleSecurity(module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleSecurity"></param>
        /// <param name="modulePermission"></param>
        public static void AddPermission(ModuleSecurity moduleSecurity, ModulePermission modulePermission)
        {
            moduleSecurity.AddPermission(modulePermission);
        }

    }

    /// <summary>
    /// The Module Security Wrapper Class
    /// </summary>
    public class ModuleSecurity
    {
        private SiteModule _module;
        private ArrayList _permissions = null;

        /// <summary>
        /// The Property for site module
        /// </summary>
        public SiteModule SiteModule
        {
            get
            {
                return _module;
            }
        }

        /// <summary>
        /// Constructor of Module Security
        /// </summary>
        /// <param name="module"></param>
        public ModuleSecurity(SiteModule module)
        {
            _module = module;
            _permissions = new ArrayList();
        }

        /// <summary>
        /// Add Permission to the Object
        /// </summary>
        /// <param name="permission">The permission enumerator</param>
        public void AddPermission(ModulePermission permission)
        {
            _permissions.Add(permission);
        }

        /// <summary>
        /// Check if the type(s) of permissions are available to user or not
        /// </summary>
        /// <param name="checkAll">True to check all and false to check any one</param>
        /// <param name="permissions">The permission enumerator</param>
        /// <returns>True if permission is there else flase</returns>
        public bool CheckPermission(bool checkAll, params ModulePermission[] permissions)
        {
            if (0 >= permissions.Length) return false;
            if (checkAll)
            {
                for (int idx = 0; idx < permissions.Length; idx++)
                {
                    if (!_permissions.Contains(permissions[idx]))
                        return (false);
                }
                return (true);
            }
            else
            {
                for (int idx = 0; idx < permissions.Length; idx++)
                {
                    if (_permissions.Contains(permissions[idx]))
                        return (true);
                }
                return (false);
            }
        }
    }
}
