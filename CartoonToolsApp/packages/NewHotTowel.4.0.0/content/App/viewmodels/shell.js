﻿define(['durandal/system', 'plugins/router', 'services/repositoy'],
    function (system, router, repositoy) {
        var shell = {
            activate: activate,
            router: router
        };

        return shell;

        //#region Internal Methods
        function activate() {
            return Q.all([repositoy.prime()]).then(function () {
                boot();
            });                          
        }

        function boot() {
            
            router.on('router:route:not-found', function (fragment) {
                logError('No Route Found', fragment, true);
            });

            var routes = [
                { route: '', moduleId: 'home', title: 'Home', nav: false},
            ];

            return router.makeRelative({ moduleId: 'viewmodels' }) // router will look here for viewmodels by convention
                .map(routes)            // Map the routes
                .buildNavigationModel() // Finds all nav routes and readies them
                .activate();            // Activate the router
        }

        function log(msg, data, showToast) {
            logger.log(msg, data, system.getModuleId(shell), showToast);
        }

        function logError(msg, data, showToast) {
            logger.logError(msg, data, system.getModuleId(shell), showToast);
        }
        //#endregion
    });