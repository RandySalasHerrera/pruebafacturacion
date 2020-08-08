import { Injector } from '@angular/core';

export abstract class ServiceBase {
    constructor(injector: Injector) { }

    getUrlFilter(
        url: string = '',
        filter: string,
        pageSize: number = 10,
        pageNo: number = 1,
        sortColumn: string,
        sortOrder: string
    ): string {
        if (filter != null) {
            if (filter !== undefined && filter.indexOf('=') < 0) {
                url += 'filter=' + encodeURIComponent('' + filter) + '&';
            }

            if (filter !== undefined && filter.indexOf('=') > 0) {
                url += filter + '&';
            }
        }

        if (pageNo === undefined || pageNo === null) {
            throw new Error(
                'The parameter \'pageNo\' must be defined and cannot be null.'
            );
        } else {
            url += 'PageNo=' + encodeURIComponent('' + pageNo) + '&';
        }

        if (pageSize === undefined || pageSize === null) {
            throw new Error(
                'The parameter \'PageSize\' must be defined and cannot be null.'
            );
        } else {
            url += 'PageSize=' + encodeURIComponent('' + pageSize) + '&';
        }
        if (sortColumn != null && sortColumn !== undefined) {
            url += 'SortColumn=' + encodeURIComponent('' + sortColumn) + '&';
        }

        if (sortOrder != null && sortOrder !== undefined) {
            url += 'SortOrder=' + encodeURIComponent('' + sortOrder) + '&';
        }

        url = url.replace(/[?&]$/, '');
        return url;
    }
}
