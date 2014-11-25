define(['services/logger','services/repositoy'], function (logger, repositoy) {
    
    var saveEmployee = ko.observable();

    var saveEmployeeDetails = function () {
        if (saveEmployee().errors().length > 0) {
            var error = saveEmployee().errors.showAllMessages();            
        }
        else {
            repositoy.save().then(function (data) {
                if (data != undefined) {
                    saveEmployee(repositoy.createEmployeeNullo());
                    toastr.success("Successfully saved");
                }
            });            
        }
    }

    var vm = {
        activate: activate,
        saveEmployee: saveEmployee,
        saveEmployeeDetails: saveEmployeeDetails,
    };

    return vm;

    //#region Internal Methods
    function activate() {
        saveEmployee(repositoy.createEmployeeNullo());
        return true;
    }
    //#endregion
});