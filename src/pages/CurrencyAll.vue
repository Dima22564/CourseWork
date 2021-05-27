<template>
  <q-page padding>
    <q-table
      title="Зарегистрированные валюты"
      :data="currencies"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="tableLoading"
    >
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              :value="props.row.name"
              @input="changeCurrencyProp($event, props.row.numericCode, 'name')"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.name" @input="changeCurrencyProp($event, props.row.numericCode, 'name')" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="numericCode" :props="props">
            {{ props.row.numericCode }}
          </q-td>
          <q-td key="characterCode" :props="props">
            {{ props.row.characterCode }}
            <q-popup-edit
              :value="props.row.characterCode"
              @input="changeCurrencyProp($event, props.row.numericCode, 'characterCode')"
              title="Обновить символьный код валюты"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.characterCode" @input="changeCurrencyProp($event, props.row.numericCode, 'characterCode')" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="exchangeRate" :props="props">
            {{ props.row.exchangeRate }}
            <q-popup-edit
              :value="props.row.exchangeRate"
              @input="changeCurrencyProp($event, props.row.numericCode, 'exchangeRate')"
              title="Обновить обменный курс"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.exchangeRate" @input="changeCurrencyProp($event, props.row.numericCode, 'exchangeRate')" dense autofocus />
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
  async created () {
    try {
      await this.$store.dispatch('currency/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: 'Что-то пошло не так( Не удалось загрузить данные.'
      })
    } finally {
      this.tableLoading = false
    }
  },
  methods: {
    changeCurrencyProp (val, code, propName) {
      this.$store.commit('currency/updateCurrency', { val, code, propName })
    },
    async saveChanges (code) {
      const currency = (this.currencies).find(x => x.numericCode === code)
      const form = new FormData()
      form.append('Name', currency.name)
      form.append('CharacterCode', currency.characterCode)
      form.append('NumericCode', currency.numericCode)
      form.append('ExchangeRate', currency.exchangeRate)
      this.loading = true
      try {
        const res = await this.$store.dispatch('currency/update', form)
        if (res.status === 200) {
          this.$q.notify({
            type: 'positive',
            message: 'Валюта успешно обновлена.'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: 'Валюта не обновлена.'
        })
      } finally {
        this.loading = false
      }
    }
  },
  computed: {
    currencies () {
      return this.$store.state.currency.currencies
    }
  },
  data: () => {
    return {
      loading: false,
      tableLoading: true,
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'numericCode', label: 'Код валюты', field: 'numericCode', format: val => parseInt(val) },
        { name: 'characterCode', label: 'Символьный код валюты', field: 'characterCode' },
        { name: 'exchangeRate', label: 'Обменный курс', field: 'exchangeRate', format: val => parseFloat(val) },
        { name: 'saveChanges', label: 'Сохранить', field: 'saveChanges' }
      ]
    }
  }
}
</script>
