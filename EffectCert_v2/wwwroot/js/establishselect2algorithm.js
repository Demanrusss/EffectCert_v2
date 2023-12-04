function establishSelect2Algorithm(selectElements) {
    for (let i = 0; i < selectElements.length; i++) {
        $(selectElements[i].id).select2({
            ajax: {
                delay: 2500,
                url: selectElements[i].url,
                dataType: 'json',
                data: function (params) {
                    return {
                        searchStr: params.term
                    };
                },
                processResults: function (data) {
                    return {
                        results: $.map(data, function (item) {
                            return {
                                id: item.id,
                                text: item.name
                            };
                        })
                    };
                }
            },
            placeholder: selectElements[i].placeholder,
            selectOnClose: false
        });
    }
}