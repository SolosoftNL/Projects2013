define(['services/logger', 'modelvalidation/modelvalidation'],
    function (logger, modelvalidation) {
        var primePromise;
        var EntityQuery = breeze.EntityQuery;
        var manager = configureBreezeManager();

        function configureBreezeManager() {
            breeze.NamingConvention.camelCase.setAsDefault();
            return new breeze.EntityManager(location + "api/hottowel/");;
        }

        function prime() {
            primePromise = Q.all([manager.fetchMetadata()])
                   .then(extendMetadata);
            function extendMetadata() {
                var metadataStore = manager.metadataStore;
                modelvalidation.configureMetadataStore(metadataStore);
                var types = metadataStore.getEntityTypes();
                types.forEach(function (type) {
                    if (type instanceof breeze.EntityType) {
                        set(type.shortName, type);
                    }
                });

                function set(resourceName, entityName) {
                    metadataStore.setEntityTypeForResourceName(resourceName, entityName);
                }

            }
        }

        function cancel() {
            if (manager.hasChanges()) {
                manager.rejectChanges();
            }
        }

        function save() {
            var self = this;
            var deferred = Q.defer();
            manager.saveChanges().then(saveSucceeded).fail(saveFailed);
            function saveSucceeded(result) {
                cancel();
                deferred.resolve(result);
            }
            function saveFailed(error) {
                breeze.saveErrorMessageService.getErrorMessage(error);
                error.message = msg;
                toastr.error(error.message);
                deferred.resolve(error.message);
            }

            return deferred.promise;
        }

        function createEmployeeNullo() {
            return manager.createEntity('Employee');
        }


        var repositoy = {
            prime: prime,
            save: save,
            cancel: cancel,
            createEmployeeNullo: createEmployeeNullo,
        };

        return repositoy;
    });