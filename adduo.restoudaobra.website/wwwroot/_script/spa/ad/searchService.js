ROApp.service('searchService', ['$http', 'searchFactory', function ($http, searchFactory) {

    this.search = function (term) {
        return $http.get('/api/search?term=' + term);
    }
 
}]);

ROApp.service('pagerSearchService', function () {

    this.productList = [];
    this.page = { columns: [], end: false };
    this.pagesize = 5;
    this.pagecount = 0;
    this.numberColumns = 1;
    this.current = 0;

    this.declarations = function ()
    {
        this.page = { columns: [], end: false };
        this.pagecount = 0;
        this.numberColumns = 1;
        this.current = 0;
    }

    this.list = function (outerWidth)
    {
        this.declarations();

        return this.init(this.productList, this.pagesize, outerWidth)
    }

    this.init = function (productList, pageSize, outerWidth) {

        this.declarations();

        this.productList = productList;
        this.pagesize = pageSize;

        this.numberColumnsCalculate(outerWidth)

        if (this.productList.length) {

            this.createColumns();

            this.pagecount = Math.ceil(this.productList.length / this.pagesize);
        }

        return this.next();
    }

    this.numberColumnsCalculate = function (outerWidth) {
        if (outerWidth > 800) {
            this.numberColumns = 3;
        }
        else if (outerWidth > 500) {
            this.numberColumns = 2;
        } else {
            this.numberColumns = 1;
        }
    }

    this.surffle = function (source) {

        var _surffle = source.sort(function () { return 0.7 - Math.random() });

        for (var i = 0; i < _surffle.length; i++) {
            _surffle[i]['rnd'] = i;
        }

        source = _surffle.sort(function (a, b) { return a.id - b.id })
    }

    this.next = function () {

        var products = this.productList.slice((this.pagesize * this.current), (this.pagesize * this.current) + this.pagesize);

        this.surffle(products);

        var control = 0

        for (var s = 0; s < products.length; s++) {
            this.page.columns[control].push(products[s]);
            control = (control === (this.numberColumns - 1)) ? 0 : control + 1;
        }

        this.current++;

        this.page.end = this.current > (this.pagecount - 1);

        return this.page;
    }

    this.createColumns = function () {

        this.numberColumns = (this.numberColumns > this.pagesize) ? this.pagesize : this.numberColumns;

        this.page.columns = [];

        for (var c = 0; c < this.numberColumns ; c++) {
            this.page.columns[c] = [];
        }
    }

});

