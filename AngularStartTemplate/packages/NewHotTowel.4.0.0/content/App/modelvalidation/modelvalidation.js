define(['durandal/system'],
    function (system) {

        var entityNames = {            
            employee: 'Employee',           
        };

        function createNullos(manager) {
            var unchanged = breeze.EntityState.Unchanged;

            function createNullo(entityName) {
                return manager.createEntity(entityName, null, unchanged);
            }
        }

        function configureMetadataStore(metadataStore) {
            metadataStore.registerEntityTypeCtor(entityNames.employee, function () { }, employeeRegisteration);            
        };

        function employeeRegisteration(employee) {
            employee.firstName = ko.observable().extend({
                required:
                {
                    message: 'First name is required',
                },
                maxLength: 10,
            });
            employee.lastName = ko.observable().extend({
                required:
                {
                    message: 'Last name is required',
                },
                maxLength: 10,
            });
            employee.errors = ko.validation.group(employee);
        }

        var modelvalidation = {
            entityNames: entityNames,
            configureMetadataStore: configureMetadataStore,
            createNullos: createNullos,
        };        

        return modelvalidation;
     
    });