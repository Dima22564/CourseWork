<template>
  <q-page padding>
    <q-table
      title="Зарегистрированные валюты"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
    >
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="numericCode" :props="props">
            {{ props.row.numericCode }}
            <q-popup-edit
              v-model="props.row.numericCode"
              title="Обновить код валюты"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.numericCode" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="characterCode" :props="props">
            {{ props.row.characterCode }}
            <q-popup-edit
              v-model="props.row.characterCode"
              title="Обновить символьный код валюты"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.characterCode" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="exchangeRate" :props="props">
            {{ props.row.exchangeRate }}
            <q-popup-edit
              v-model="props.row.exchangeRate"
              title="Обновить обменный курс"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.exchangeRate" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="saveChanges" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.numericCode)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </q-page>
</template>

<script>
export default {
  name: 'PageCurrencyAll',
  methods: {
    saveChanges (code) {
      this.loading = true
      // /currency/change/code
    }
  },
  data: () => {
    return {
      loading: false,
      data: [
        { name: 'Доллар', numericCode: 201, characterCode: 'USD', exchangeRate: 66.12, saveChanges: '' },
        { name: 'Рубль', numericCode: 452, characterCode: 'РУБ', exchangeRate: 1, saveChanges: '' }
      ],
      columns: [
        {
          name: 'name',
          label: 'Название',
          align: 'left',
          field: 'name'
        },
        { name: 'numericCode', label: 'Код валюты', field: 'numericCode', format: val => parseInt(val) },
        { name: 'characterCode', label: 'Символьный код валюты', field: 'characterCode' },
        { name: 'exchangeRate', label: 'Обменный курс', field: 'exchangeRate', format: val => parseFloat(val) },
        { name: 'saveChanges', label: 'Сохранить', field: 'saveChanges' }
      ]
    }
  }
}
</script>
