ROApp.factory('adFactory', ['baseFactory', function (baseFactory) {

    var _type = {
        none: 0,
        donation: 1,
        sale: 2
    };

    var _status = {
        none: 0,
        published: 1,
        finished: 2,
        paused: 3,
    };


    var _resetAddress = function (dto) {
        baseFactory.helper.addProperty('id', 0, dto.address);
        baseFactory.helper.addProperty('city', '', dto.address);
        baseFactory.helper.addProperty('state', { id: 0, code: '', name: '' }, dto.address);
        baseFactory.helper.addProperty('district', '', dto.address);
        dto.address['newOrUpdate'] = false;
    }


    var _createDTO = function () {

        var dto = {
            product: {
                id: 0,
                guid: '',
                type: 0,
                status: 0
            },
            images: [],
            address: {},
        };

        baseFactory.helper.addProperty('name', '', dto.product);
        baseFactory.helper.addProperty('option', '', dto.product);
        baseFactory.helper.addProperty('brand', '', dto.product);
        baseFactory.helper.addProperty('quantity', '', dto.product);
        baseFactory.helper.addProperty('price', '', dto.product);
        baseFactory.helper.addProperty('state', '', dto.product);

        baseFactory.helper.addPropertyList('images', [], dto);

        _resetAddress(dto);

        return dto;
    }



    var _createProductDonation = function () {
        var dto = _createDTO();
        dto.product.type = _type.donation;
        return dto;
    }

    var _createProductSale = function () {
        var dto = _createDTO();
        dto.product.type = _type.sale;
        return dto;
    }

    var _createChangeStatusDTO = function (product, status) {
        return { "id": product.id, "status": status };
    }

    var _createChangeStatusPublishedDTO = function (product) {
        return _createChangeStatusDTO(product, _status.published);
    }

    var _createChangeStatusFinishedDTO = function (product) {
        return _createChangeStatusDTO(product, _status.finished);
    }

    var _createChangeStatusPausedDTO = function (product) {
        return _createChangeStatusDTO(product, _status.paused);
    }

    var _isStatusPublished = function (idStatus) {
        return idStatus === _status.published;
    }

    var _isStatusFinished = function (idStatus) {
        return idStatus === _status.finished;
    }

    var _isStatusPaused = function (idStatus) {
        return idStatus === _status.paused;
    }

    var _productTypeDonation = function (product) {

        var result = false;

        if (product) {
            result = product.type === _type.donation;
        }

        return result;
    }

    var _productTypeSale = function (product) {

        var result = false;

        if (product) {
            result = product.type === _type.sale;
        }

        return result;
    }


    var _createRequest = function (dto, culture) {
        var baserequest = baseFactory.helper.createRequest(dto, culture, true);
        return baserequest;
    }

    var _factory = {
        helper: {
            createRequest: _createRequest,
            createDTO: _createDTO,
            createProductDonation: _createProductDonation,
            createProductSale: _createProductSale,
            resetAddress: _resetAddress,
            productTypeDonation: _productTypeDonation,
            productTypeSale: _productTypeSale,
            createChangeStatusPublishedDTO: _createChangeStatusPublishedDTO,
            createChangeStatusPausedDTO: _createChangeStatusPausedDTO,
            createChangeStatusFinishedDTO: _createChangeStatusFinishedDTO,
            isStatusPublished: _isStatusPublished,
            isStatusFinished: _isStatusFinished,
            isStatusPaused: _isStatusPaused,
        },
        data: {
            type: _type,
            status: _status
        }
    };

    return _factory;
}]);
