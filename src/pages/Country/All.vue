<template>
  <q-page padding>
    <q-table
      title="Зарегистрированные страны"
      :data="countries"
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
              @input="changeCountryProp($event, props.row.code, 'name')"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.name" @input="changeCountryProp($event, props.row.code, 'name')" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="code" :props="props">
            {{ props.row.code }}
          </q-td>
          <q-td key="fullName" :props="props">
            {{ props.row.fullName }}
            <q-popup-edit
              :value="props.row.fullName"
              @input="changeCountryProp($event, props.row.code, 'fullName')"
              title="Обновить символьный код валюты"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.fullName" @input="changeCountryProp($event, props.row.code, 'fullName')" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="code2" :props="props">
            {{ props.row.code2 }}
            <q-popup-edit
              :value="props.row.code2"
              @input="changeCountryProp($event, props.row.code, 'code2')"
              title="Обновить обменный курс"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.code2" @input="changeCountryProp($event, props.row.code, 'code2')" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="code3" :props="props">
            {{ props.row.code3 }}
            <q-popup-edit
              :value="props.row.code3"
              @input="changeCountryProp($event, props.row.code, 'code3')"
              title="Обновить обменный курс"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input :value="props.row.code3" @input="changeCountryProp($event, props.row.code, 'code3')" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.code)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>
  </q-page>
</template>

<script>
export default {
  name: 'PageCountriesAll',
  async created () {
    try {
      await this.$store.dispatch('country/fetchAll')
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
    changeCountryProp (val, code, propName) {
      this.$store.commit('country/updateCountry', { val, code, propName })
    },
    async saveChanges (code) {
      const country = (this.countries).find(x => x.code === code)
      const form = new FormData()
      form.append('Code', country.code)
      form.append('Name', country.name)
      form.append('FullName', country.fullName)
      form.append('Code2', country.code2)
      form.append('Code3', country.code3)
      this.loading = true
      try {
        const res = await this.$store.dispatch('country/update', form)
        if (res.status === 200) {
          this.$q.notify({
            type: 'positive',
            message: 'Страна успешно обновлена.'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: 'Страна не обновлена.'
        })
      } finally {
        this.loading = false
      }
    }
  },
  computed: {
    countries () {
      return this.$store.state.country.countries
    }
  },
  data: () => {
    return {
      loading: false,
      tableLoading: true,
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'code', label: 'Код страны', field: 'code', format: val => parseInt(val) },
        { name: 'fullName', label: 'Полное название', field: 'fullName' },
        { name: 'code2', label: 'Символьный код(2)', field: 'code2', format: val => parseFloat(val) },
        { name: 'code3', label: 'Символьный код(3)', field: 'code3' },
        { name: 'actions', label: '', field: 'actions' }
      ]
    }
  }
}
</script>
